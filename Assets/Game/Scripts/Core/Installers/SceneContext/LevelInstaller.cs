using Core.SceneLoading;
using Zenject;

namespace Core.Installers
{
    public class LevelInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<SceneLoader_Instant>().AsSingle();
        }
    }
}
