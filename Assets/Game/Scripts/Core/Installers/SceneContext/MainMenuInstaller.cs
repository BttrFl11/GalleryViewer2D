using Core.SceneLoading;
using UnityEngine;
using Zenject;

namespace Core.Installers
{
    public class MainMenuInstaller : MonoInstaller
    {
        [SerializeField] private LoadingScreen _loadingScreen;

        public override void InstallBindings()
        {
            BindSceneLoad();
        }

        private void BindSceneLoad()
        {
            Container.BindInstance<LoadingScreen>(_loadingScreen).AsSingle();
            Container.BindInterfacesAndSelfTo<SceneLoader_Animated>().AsSingle();
        }
    }
}