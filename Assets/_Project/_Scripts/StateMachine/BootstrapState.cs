using _Project._Scripts.Services;

namespace _Project._Scripts.Infrastructure.GameStates
{
    public class BootstrapState : GameStateBase
    {
        private SceneLoader _sceneLoader;

        public BootstrapState(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public override void Enter()
        {
            _stateMachine.EnterState<CubesState>();
        }
    }
}