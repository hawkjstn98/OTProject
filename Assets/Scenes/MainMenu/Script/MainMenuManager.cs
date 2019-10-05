using System;
using System.Collections;
using System.Collections.Generic;
using Assets.GameSystem.Constant.Enum;
using GameSystem.Service;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject continueButton;
    private void Awake()
    {
        if (EventService.CheckPointExist())
        {
            continueButton.SetActive(true);
        }
    }

    public void ToSettings()
    {
        SceneService.Instance.ChangeScene(SceneEnum.Settings);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
