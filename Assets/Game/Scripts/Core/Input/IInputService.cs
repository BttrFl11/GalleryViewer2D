using System;

namespace Core.Input
{
    public interface IInputService
    {
        event Action OnBack;

        void Tick();
    }
}
