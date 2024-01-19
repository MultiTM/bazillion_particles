using _Project._Scripts.Infrastructure.Utils;
using UnityEngine;

public class ParticleEmitter : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private Transform _target;
    private ParticleSystem.Particle[] particles = new ParticleSystem.Particle[50];

    private void Update()
    {
        particles.Clean();
        var count = _particleSystem.GetParticles(particles);

        for (int i = 0; i < count; i++)
        {
            var particle = particles[i];

            var particleSystemPosition = _particleSystem.transform.TransformPoint(particle.position);
            var targetPosition = _target.position;

            var particleTargetPosition = (targetPosition - particleSystemPosition) * ( particle.remainingLifetime / particle.startLifetime);
            particle.position = _particleSystem.transform.InverseTransformPoint(targetPosition - particleTargetPosition);
            particles[i] = particle;
        }

        _particleSystem.SetParticles(particles, count);
    }
}