using System.Collections;
using System.Collections.Generic;
using GameSystem.Entity;
using GameSystem.Service;
using UnityEngine;

public class Tst : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameSettings gameSettings = PreferencesService.LoadSettings();
        GameSettings updateSettings = new GameSettings();
        updateSettings.Lighting = 70;
        updateSettings.Volume = 70;
        updateSettings.FieldOfView = 70;
        PreferencesService.WriteSettings(updateSettings);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
