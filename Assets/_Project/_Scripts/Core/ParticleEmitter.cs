using UnityEngine;

public class ParticleEmitter : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private Transform _target;

    private void Update()
    {
        var particles = new ParticleSystem.Particle[50];
        var count = _particleSystem.GetParticles(particles);

        for (int i = 0; i < count; i++)
        {
            var particle = particles[i];

            Vector3 v1 = _particleSystem.transform.TransformPoint(particle.position);
            Vector3 v2 = _target.position;

            Vector3 tarPosi = (v2 - v1) *  (particle.remainingLifetime / particle.startLifetime);
            particle.position = _particleSystem.transform.InverseTransformPoint(v2 - tarPosi);
            particles[i] = particle;
        }

        _particleSystem.SetParticles(particles, count);
    }
}