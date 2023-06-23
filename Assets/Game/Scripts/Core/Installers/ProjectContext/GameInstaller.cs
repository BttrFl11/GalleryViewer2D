using Core.Gallery;
using Core.Interfaces;
using Zenject;

namespace Core.Installers
{
    public class GameInstaller : MonoInstaller, ICoroutineRunner
    {
        public override void InstallBindings()
        {
            Container.BindInstance<ICoroutineRunner>(this).AsSingle();

            Container.Bind<SelectedImageInfo>().AsSingle();
        }
    }
}