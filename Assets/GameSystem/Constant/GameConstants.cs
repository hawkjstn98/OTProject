using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConstants : MonoBehaviour
{
    public static GameConstants Instance;
    private float GRAVITY_SCALE = 1.0f;
    private static float GLOBAL_GRAVITY_SCALE = -9.81f;

    private void Awake()
    {
        Instance = this;
    }

    public float GetGravityScale()
    {
        return GRAVITY_SCALE;
    }
    
    public float GetGlobalGravityScale()
    {
        return GLOBAL_GRAVITY_SCALE;
    }
    
    public void SetGravityScale(float GRAVITY_SCALE)
    {
        this.GRAVITY_SCALE = GRAVITY_SCALE;
    }
}
