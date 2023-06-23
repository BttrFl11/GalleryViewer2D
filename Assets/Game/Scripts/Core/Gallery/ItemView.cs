using Core.SceneLoading;
using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Core.Gallery
{
    public class ItemView : MonoBehaviour
    {
        [SerializeField] private RawImage _image;
        [SerializeField] private Button _selectImageButton;

        private RectTransform _rect;

        private bool _appeared = false;
        private bool _inited = false;
        private float _cameraBottomPlacePositionY;
        private ImageLoader _imageLoader;
        private Camera _camera;
        private SelectedImageInfo _selectedImageInfo;
        private ISceneLoader _sceneLoader;

        public static event Action<ItemView> OnAppearOnScreen;

        [Inject]
        private void Construct(ImageLoader imageLoader, ISceneLoader sceneLoder, SelectedImageInfo selectedImageInfo)
        {
            _imageLoader = imageLoader;
            _sceneLoader = sceneLoder;
            _selectedImageInfo = selectedImageInfo;
        }

        private void Awake()
        {
            _rect = _image.GetComponent<RectTransform>();
            _camera = Camera.main;

            _cameraBottomPlacePositionY = -_camera.orthographicSize;
        }

        private void OnEnable()
        {
            _imageLoader.OnImageLoadError += OnLoadError;
            _selectImageButton.onClick.AddListener(SelectImage);
        }

        private void OnDisable()
        {
            _imageLoader.OnImageLoadError -= OnLoadError;
            _selectImageButton.onClick.RemoveListener(SelectImage);
        }

        private void SelectImage()
        {
            if (_inited == false) return;

            _selectedImageInfo.Texture = (Texture2D)_image.texture;

            _sceneLoader.LoadImageView();
        }

        public void Init(Texture2D texture)
        {
            _image.texture = texture;

            if (texture.width < _rect.rect.width || texture.height < _rect.rect.height)
                _image.rectTransform.sizeDelta = new Vector2(texture.width, texture.height);

            _inited = true;
        }

        public void OnLoadError()
        {
            if (_inited) return;

            Destroy(gameObject);
        }

        private void CheckBorder()
        {
            if (_appeared) return;

            if (transform.position.y > _cameraBottomPlacePositionY)
            {
                OnAppearOnScreen?.Invoke(this);
                _appeared = true;
            }
        }

        private void Update()
        {
            CheckBorder();
        }
    }
}
