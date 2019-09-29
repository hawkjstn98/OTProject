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
        private string scene;

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
                StartCoroutine(LoadSceneAsync());
                isActive = false;
            }
        }

        public void ChangeScene(SceneEnum sceneEnum)
        {
            scene = sceneEnum.ToString();
            isActive = true;
        }

        IEnumerator LoadSceneAsync()
        {
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(scene);
            while (!asyncOperation.isDone)
            {
                yield return null;
            }
        }
    }
}

