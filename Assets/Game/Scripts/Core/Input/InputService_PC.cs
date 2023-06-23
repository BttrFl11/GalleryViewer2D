using System;
using UnityEngine;
using static UnityEngine.Input;

namespace Core.Input
{
    public class InputService_PC : IInputService
    {
        public event Action OnBack;

        public void Tick()
        {
            if (GetKeyDown(KeyCode.Escape))
            {
                OnBack?.Invoke();
            }
        }
    }
}
