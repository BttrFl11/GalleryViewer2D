using System;
using UnityEngine;
using static UnityEngine.Input;

namespace Core.Input
{
    public class InputService_Android : IInputService
    {
        public event Action OnBack;

        public void Tick()
        {
            if (GetKeyUp(KeyCode.Escape))
            {
                OnBack?.Invoke();
            }
        }
    }
}
