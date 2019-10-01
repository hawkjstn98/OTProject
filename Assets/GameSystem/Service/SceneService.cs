using System;
using System.Collections;
using System.Collections.Generic;
using Assets.GameSystem.Constant.Enum;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameSystem.Service
{
    //SceneService Is Singleton Class
    public class SceneService : MonoBehaviour
    {
        public static SceneService Instance;
        private bool isActive;
        private bool isLoading;
        private string scene;
        private float progress;
        private AsyncOperation sceneOperation;

        void Awake()
        {
            Instance = this;
            isActive = false;
            DontDestroyOnLoad(this);
        }

        void Update()
        {
            if (isActive)
            {
                progress = 0;
                StartCoroutine(LoadSceneAsync());
                isActive = false;
            }
        }
        
        public void ChangeScene(SceneEnum sceneEnum)
        {
            scene = sceneEnum.ToString();
            StartCoroutine(ToLoadingScene());
        }

        IEnumerator ToLoadingScene()
        {
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(SceneEnum.Loading.ToString());
            while (asyncOperation.isDone)
            {
                yield return null;
            }
            isActive = true;
        }

        IEnumerator LoadSceneAsync()
        {
            sceneOperation = SceneManager.LoadSceneAsync(scene);
            sceneOperation.allowSceneActivation = false;
            while (!sceneOperation.isDone)
            {
                progress = sceneOperation.progress;
                yield return null;
            }
        }

        public float GetProgress()
        {
            return progress;
        }

        public void JumpToScene()
        {
            sceneOperation.allowSceneActivation = true;
        }
    }
}

