using System;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace _Project._Scripts.Services
{
    public class SceneLoader
    {
        private const string CubesScene = "Cubes";
        private const string ParticlesScene = "Particles";

        public async void LoadCubesScene()
        {
            await LoadSceneAsync(CubesScene);
        }

        public async void LoadParticlesScene()
        {
            await LoadSceneAsync(ParticlesScene);
        }

        public async void UnloadCubesScene()
        {
            await UnloadSceneAsync(CubesScene);
        }

        public async void UnloadParticlesScene()
        {
            await UnloadSceneAsync(ParticlesScene);
        }

        private async UniTask UnloadSceneAsync(string sceneName)
        {
            await SceneManager.UnloadSceneAsync(sceneName);
        }

        private async UniTask LoadSceneAsync(string sceneName)
        {
            await SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        }
    }
}