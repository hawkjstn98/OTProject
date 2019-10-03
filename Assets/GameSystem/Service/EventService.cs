using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Assets.GameSystem.Constant.Enum;
using Assets.GameSystem.Lib;
using GameSystem.Constant;
using GameSystem.Entity;
using UnityEngine;

namespace GameSystem.Service
{
    public class EventService : MonoBehaviour
    {
        private static readonly string CHECKPOINT_FILES = PathConstants.DATA_PATH + PathConstants.CHECKPOINT_FILE;
        
        /// <summary>
        /// Save characters data, when checkpoint reaches
        /// </summary>
        /// <param name="checkPoint">Recieve CheckPoint Class Parameter</param>
        public static void WriteCheckPoint(CheckPoint checkPoint)
        {
            string json = FileHelper<CheckPoint>.ObjectParserToJsonString(checkPoint);
            File.WriteAllText(PathConstants.DATA_PATH+PathConstants.CHECKPOINT_FILE,
                json);
        }

        /// <summary>
        /// Load CheckPoint from file
        /// </summary>
        /// <returns>Return CheckPoint</returns>
        public static CheckPoint LoadCheckPoint()
        {
            if (CheckPointExist())
            {
                string json = File.ReadAllText(CHECKPOINT_FILES);
                CheckPoint checkPoint = FileHelper<CheckPoint>.JsonStringParserToObject(json, new CheckPoint());
                return checkPoint;
            }

            Debug.Log("FILE not Found Return empty");
            return new CheckPoint();
        }

        /// <summary>
        /// Search If Checkpoint Exist;
        /// </summary>
        /// <returns>return true if CheckPoint Exist, return false
        /// if CheckPoint not Exist</returns>
        public static bool CheckPointExist()
        {
            return FileHelper<CheckPoint>.FileExist(CHECKPOINT_FILES);
        }



        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }
    }
}