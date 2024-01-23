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
        private int _workloads;
        private ComputeBuffer _positionBuffer;
        private ComputeBuffer _velocityBuffer;
        private Matrix4x4[] _particles;
        private Vector3[] _velocities;
        
        private readonly uint[] _args = { 0, 0, 0, 0, 0 };
        private ComputeBuffer _argsBuffer;

        private void Start()
        {
            _particles = new Matrix4x4[_maxParticles];
            _velocities = new Vector3[_maxParticles];
            for (int i = 0; i < _maxParticles; i++)
            {
                _particles[i] = Matrix4x4.TRS(Vector3.one, Quaternion.identity, Vector3.one);
                _velocities[i] = Random.onUnitSphere * Random.Range(1f, 2f);
            }
            
            _positionBuffer = new ComputeBuffer(_maxParticles, sizeof(float) * 16);
            _positionBuffer.SetData(_particles);
            _velocityBuffer = new ComputeBuffer(_maxParticles, sizeof(float) * 3);
            _velocityBuffer.SetData(_velocities);
            _kernel = _computeShader.FindKernel("CSMain");
            
            _computeShader.SetBuffer(_kernel, "positionBuffer", _positionBuffer);
            _computeShader.SetBuffer(_kernel, "velocityBuffer", _velocityBuffer);
            _material.SetBuffer("positionBuffer", _positionBuffer);
            _workloads = Mathf.CeilToInt(_maxParticles / 100f);
            
            _argsBuffer = new ComputeBuffer(1, _args.Length * sizeof(uint), ComputeBufferType.IndirectArguments);
            
            _args[0] = _mesh.GetIndexCount(0);
            _args[1] = (uint)_maxParticles;
            _args[2] = _mesh.GetIndexStart(0);
            _args[3] = _mesh.GetBaseVertex(0);

            _argsBuffer.SetData(_args);
        }

        private void OnDestroy()
        {
            _positionBuffer?.Release();
            _positionBuffer = null;
            _velocityBuffer?.Release();
            _velocityBuffer = null;
            _argsBuffer?.Release();
            _argsBuffer = null;
        }

        private void Update()
        {
            _computeShader.Dispatch(_kernel, _workloads, 1, 1);
            Graphics.DrawMeshInstancedIndirect(_mesh, 0, _material, new Bounds(Vector3.zero, Vector3.one * 100), _argsBuffer);
        }
    }
    
}