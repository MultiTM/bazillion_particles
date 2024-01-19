using UnityEngine;

namespace _Project._Scripts.Infrastructure.Core
{
    public class ParticleEmitter : MonoBehaviour
    {
        [SerializeField] private int _maxParticles = 1_000_000;
        [SerializeField] private ComputeShader _computeShader;
        [SerializeField] private Mesh _mesh;
        [SerializeField] private Material _material;
        
        private int _kernel;
        private ComputeBuffer _positionBuffer;
        private ComputeBuffer _velocityBuffer;
        private Matrix4x4[] _particles;
        private Vector3[] _velocities;

        private void Start()
        {
            _particles = new Matrix4x4[_maxParticles];
            _velocities = new Vector3[_maxParticles];
            for (int i = 0; i < _maxParticles; i++)
            {
                _particles[i] = Matrix4x4.TRS(Vector3.one, Quaternion.identity, Vector3.one);
                _velocities[i] = Random.onUnitSphere * 0.1f;
            }
            
            _positionBuffer = new ComputeBuffer(_maxParticles, sizeof(float) * 16, ComputeBufferType.Structured);
            _positionBuffer.SetData(_particles);
            _velocityBuffer = new ComputeBuffer(_maxParticles, sizeof(float) * 3, ComputeBufferType.Structured);
            _velocityBuffer.SetData(_velocities);
            _kernel = _computeShader.FindKernel("CSMain");
        }

        private void OnDestroy()
        {
            _positionBuffer?.Release();
            _positionBuffer = null;
            _velocityBuffer?.Release();
            _velocityBuffer = null;
        }

        private void Update()
        {
            _computeShader.SetBuffer(_kernel, "positionBuffer", _positionBuffer);
            _computeShader.SetBuffer(_kernel, "velocityBuffer", _velocityBuffer);
            var workloads = Mathf.CeilToInt(_maxParticles / 16f);
            _computeShader.Dispatch(_kernel, workloads, 1, 1);
            
            _positionBuffer.GetData(_particles);
            _velocityBuffer.GetData(_velocities);
            
            Graphics.DrawMeshInstanced(_mesh, 0, _material, _particles);
        }
    }
    
}