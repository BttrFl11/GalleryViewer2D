using System.Collections;
using UnityEngine;

namespace Core.Interfaces
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator routine);
    }
}
