using Core.SceneLoading;
using UnityEngine;
using Zenject;

namespace UI
{
    public class LoadSceneButton : MonoBehaviour
    {
        private ISceneLoader _sceneLoader;

        [Inject]
        private void Construct(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public void Load(int sceneId)
        {
            _sceneLoader.Load(sceneId);
        }

        public void LoadNext()
        {
            _sceneLoader.LoadNext();
        }

        public void LoadMenu()
        {
            _sceneLoader.LoadMenu();
        }

        public void LoadImageView()
        {
            _sceneLoader.LoadImageView();
        }

        public void LoadGallery()
        {
            _sceneLoader.LoadGallery();
        }
    }
}