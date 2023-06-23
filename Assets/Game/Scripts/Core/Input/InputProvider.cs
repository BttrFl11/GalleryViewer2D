using Zenject;

namespace Core.Input
{
    public class InputProvider : ITickable
    {
        private IInputService _inputService;

        public InputProvider(IInputService inputService)
        {
            _inputService = inputService;
        }

        public void Tick()
        {
            _inputService.Tick();
        }
    }
}
