using _Project._Scripts.Services;

namespace _Project._Scripts.Infrastructure.GameStates
{
    public class CubesState : GameStateBase
    {
        private SceneLoader _sceneLoader;

        public CubesState(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public override void Enter()
        {
            _sceneLoader.LoadCubesScene();
        }

        public override void Exit()
        {
            _sceneLoader.UnloadCubesScene();
        }
    }
}