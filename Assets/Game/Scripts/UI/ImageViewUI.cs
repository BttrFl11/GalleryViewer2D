using Core.Gallery;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class ImageViewUI : MonoBehaviour
    {
        [SerializeField] private RawImage _image;

        [Inject]
        private void Construct(SelectedImageInfo imageInfo)
        {
            _image.texture = imageInfo.Texture;
            _image.SetNativeSize();
        }
    }
}