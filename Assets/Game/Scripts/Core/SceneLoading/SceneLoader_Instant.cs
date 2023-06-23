using Core.Input;
using System;
using UnityEngine.SceneManagement;

namespace Core.SceneLoading
{
    public class SceneLoader_Instant : ISceneLoader, IDisposable
    {
        private IInputService _inputService;

        public SceneLoader_Instant(IInputService inputService)
        {
            _inputService = inputService;

            _inputService.OnBack += LoadPrevious;
        }

        public void Dispose()
        {
            _inputService.OnBack -= LoadPrevious;
        }

        public void Load(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }

        public void LoadPrevious()
        {
            if (SceneManager.GetActiveScene().buildIndex == 0)
                return;

            Load(SceneManager.GetActiveScene().buildIndex - 1);
        }

        public void LoadNext()
        {
            Load(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void LoadMenu()
        {
            SceneManager.LoadScene((int)Scenes.MainMenu);
        }

        public void LoadImageView()
        {
            SceneManager.LoadScene((int)Scenes.ImageView);
        }

        public void LoadGallery()
        {
            SceneManager.LoadScene((int)Scenes.Gallery);
        }
    }
}
