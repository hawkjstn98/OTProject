using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.GameSystem.Entity
{
    [Serializable]
    public class GameSettings
    {
        [SerializeField]private int volume;
        [SerializeField]private int lighting;
        [SerializeField]private int fieldOfView;

        public int Volume
        {
            get => volume;
            set => volume = value;
        }

        public int Lighting
        {
            get => lighting;
            set => lighting = value;
        }

        public int FieldOfView
        {
            get => fieldOfView;
            set => fieldOfView = value;
        }

        public void minVolume()
        {
            volume--;
        }
        
        public void minLighting()
        {
            lighting--;
        }

        public void minFOV()
        {
            fieldOfView--;
        }

        public void plusVolume()
        {
            volume++;
        }

        public void plusLighting()
        {
            lighting++;
        }

        public void plusFOV()
        {
            fieldOfView++;
        }
    }
}



