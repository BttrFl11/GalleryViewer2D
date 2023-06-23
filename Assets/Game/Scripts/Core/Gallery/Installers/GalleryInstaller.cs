using Zenject;

namespace Core.Gallery
{
    public class GalleryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<Gallery>().FromComponentInHierarchy().AsSingle();
            Container.Bind<ImageLoader>().AsSingle();
            Container.BindInterfacesAndSelfTo<GalleryController>().AsSingle();
        }
    }
}
