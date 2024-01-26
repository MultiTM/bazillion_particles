<h1>Bazillion particles project</h1>

<h2>Used optimization technics:</h2>

- 20 spheres in Cubes scene are rendered in 1 DC with SRP batcher

it supports batching by shader variants instead on materials

1.000.000 particles in Particles scene are rendered using 2 technics:
- We do position computations in compute shader

This allows us to compute positions very fast in parallel as well as add custom logic to particles (not got out of sphere bounds)
- We render all particles with indirect GPU instancing - it means we have same binded GPU buffer for compute shader as well as for rendering

That's allows us not to share data with CPU at all and we save a lot of CPU time and CPU-GPU bus