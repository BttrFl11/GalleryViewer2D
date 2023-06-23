using UnityEngine;
using UnityEngine.UI;

namespace Core.Gallery
{
    public class Gallery : MonoBehaviour
    {
        [SerializeField] private RectTransform _contentRect;
        [SerializeField] private int _entryItemBoxCount;

        public RectTransform ContentRect => _contentRect;
        public int EntryItemBoxCount => _entryItemBoxCount;
    }
}