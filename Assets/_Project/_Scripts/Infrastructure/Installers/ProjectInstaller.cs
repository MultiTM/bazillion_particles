using _Project._Scripts.Infrastructure.GameStates;
using _Project._Scripts.Services;
using Zenject;

namespace _Project._Scripts.Infrastructure
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallGameStates();
            InstallServices();
        }

        private void InstallServices()
        {
            Container.Bind<SceneLoader>().AsSingle();
        }

        private void InstallGameStates()
        {
            Container.Bind<Game>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<BootstrapState>().AsSingle();
            Container.BindInterfacesAndSelfTo<CubesState>().AsSingle();
            Container.BindInterfacesAndSelfTo<ParticlesState>().AsSingle();
        }
    }
}
