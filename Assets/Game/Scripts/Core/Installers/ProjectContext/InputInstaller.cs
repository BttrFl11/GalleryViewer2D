using Core.Input;
using Zenject;

namespace Core.Installers
{
    public class InputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            if (DeviceInfo.IsMobile)
                Container.Bind<IInputService>().To<InputService_Android>().AsSingle();
            else
                Container.Bind<IInputService>().To<InputService_PC>().AsSingle();

            Container.BindInterfacesAndSelfTo<InputProvider>().AsSingle();
        }
    }
}
