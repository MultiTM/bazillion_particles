using _Project._Scripts.Services;

namespace _Project._Scripts.Infrastructure.GameStates
{
    public class ParticlesState : GameStateBase
    {
        private SceneLoader _sceneLoader;

        public ParticlesState(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public override void Enter()
        {
            _sceneLoader.LoadParticlesScene();
        }

        public override void Exit()
        {
            _sceneLoader.UnloadParticlesScene();
        }
    }
}
