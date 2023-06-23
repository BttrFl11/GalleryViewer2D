using Core.Input;
using Core.Interfaces;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.SceneLoading
{
    public class SceneLoader_Animated : ISceneLoader, IDisposable
    {
        private LoadingScreen _loadingScreen;
        private ICoroutineRunner _coroutineRunner;
        private IInputService _inputService;

        private const float FINISH_PROGRESS = 0.9f;
        private const float MIN_WAIT_TIME = 2f;

        public SceneLoader_Animated(LoadingScreen loadingScreen, ICoroutineRunner coroutineRunner, IInputService inputService)
        {
            _loadingScreen = loadingScreen;
            _coroutineRunner = coroutineRunner;
            _inputService = inputService;

            _inputService.OnBack += LoadPrevious;
        }

        public void Dispose()
        {
            _inputService.OnBack -= LoadPrevious;
        }

        private IEnumerator StartLoading(int sceneId)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);

            _loadingScreen.SetActive(true);
            operation.allowSceneActivation = false;

            float waitTime = 0;

            while (operation.isDone == false)
            {
                _loadingScreen.SetProgressBarFillAmount(operation.progress);

                waitTime += Time.deltaTime;

                if (operation.progress >= FINISH_PROGRESS)
                {
                    break;
                }

                yield return null;
            }

            _loadingScreen.SetProgressBarFillAmount(1);

            if (waitTime < MIN_WAIT_TIME)
                yield return new WaitForSeconds(MIN_WAIT_TIME - waitTime);

            operation.allowSceneActivation = true;
        }

        public void Load(int sceneId)
        {
            _coroutineRunner.StartCoroutine(StartLoading(sceneId));
        }

        public void LoadPrevious()
        {
            if (SceneManager.GetActiveScene().buildIndex == 0)
                return;

            _coroutineRunner.StartCoroutine(StartLoading(SceneManager.GetActiveScene().buildIndex - 1));
        }

        public void LoadNext()
        {
            _coroutineRunner.StartCoroutine(StartLoading(SceneManager.GetActiveScene().buildIndex + 1));
        }

        public void LoadMenu()
        {
            _coroutineRunner.StartCoroutine(StartLoading((int)Scenes.MainMenu));
        }

        public void LoadImageView()
        {
            _coroutineRunner.StartCoroutine(StartLoading((int)Scenes.ImageView));
        }

        public void LoadGallery()
        {
            _coroutineRunner.StartCoroutine(StartLoading((int)Scenes.Gallery));
        }
    }
}