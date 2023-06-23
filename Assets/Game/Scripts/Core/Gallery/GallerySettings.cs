using System;
using UnityEngine;

namespace Core.Gallery
{
    [Serializable]
    public class GallerySettings
    {
        [SerializeField] private string _galleryUrl;
        [SerializeField] private string _imagesType;
        [SerializeField] private ItemView _itemViewPrefab;

        public ItemView ItemViewPrefab => _itemViewPrefab;
        public string ImagesType => _imagesType;
        public string GalleryUrl => _galleryUrl;
    }
}
