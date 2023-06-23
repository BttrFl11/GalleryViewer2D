using UnityEngine.Networking;
using UnityEngine;
using System.Collections;
using System;

namespace Core.Gallery
{
    public class ImageLoader
    {
        private readonly string _url;
        private readonly string _imageType;

        public event Action OnImageLoadError;
        public event Action OnImageLoaded;

        public ImageLoader(GallerySettings settings)
        {
            _url = settings.GalleryUrl;
            _imageType = settings.ImagesType;
        }

        public IEnumerator LoadImage(ItemView itemView, int index)
        {
            using UnityWebRequest request = UnityWebRequestTexture.GetTexture($"{_url}{index}.{_imageType}");
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogWarning(request.error);

                OnImageLoadError?.Invoke();
            }
            else
            {
                Texture2D texture = DownloadHandlerTexture.GetContent(request);

                if (itemView != null)
                    itemView.Init(texture);

                OnImageLoaded?.Invoke();
            }
        }
    }
}
