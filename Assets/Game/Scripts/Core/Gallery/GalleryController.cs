using Core.Interfaces;
using System;
using UnityEngine;
using Zenject;

namespace Core.Gallery
{
    public class GalleryController : IDisposable
    {
        private ICoroutineRunner _coroutineRunner;
        private DiContainer _diContainer;
        private GallerySettings _settings;
        private ImageLoader _imageLoader;
        private Gallery _gallery;

        private int _index = 1;

        public GalleryController(ICoroutineRunner coroutineRunner, 
            DiContainer diContainer,
            GallerySettings settings,
            ImageLoader imageLoader,
            Gallery gallery)
        {
            _coroutineRunner = coroutineRunner;
            _diContainer = diContainer;
            _settings = settings;
            _imageLoader = imageLoader;
            _gallery = gallery;

            ItemView.OnAppearOnScreen += OnItemAppear;
            _imageLoader.OnImageLoaded += CreateItem;

            CreateEntryItems();
        }

        private void CreateEntryItems()
        {
            for (int i = 0; i < _gallery.EntryItemBoxCount; i++)
            {
                CreateItem();
            }
        }

        public void Dispose()
        {
            ItemView.OnAppearOnScreen -= OnItemAppear;
        }

        private void OnItemAppear(ItemView itemView)
        {
            _coroutineRunner.StartCoroutine(_imageLoader.LoadImage(itemView, _index));

            _index++;
        }

        private void CreateItem()
        {
            ItemView item = _diContainer.InstantiatePrefabForComponent<ItemView>(_settings.ItemViewPrefab);

            item.transform.SetParent(_gallery.ContentRect, false);
        }
    }
}