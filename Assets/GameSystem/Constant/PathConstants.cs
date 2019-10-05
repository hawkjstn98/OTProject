using System.Collections;
using System.Collections.Generic;
using System.IO;
using Assets.GameSystem.Constant.Enum;
using UnityEngine;

namespace GameSystem.Constant
{
    public abstract class PathConstants
    {
        //Path
        public static  readonly string DATA_PATH = Application.persistentDataPath;
            
        
        //File
        public const string SETTING_FILE = "Settings.json";
        public const string CHECKPOINT_FILE = "Checkpoint.json";
        

        /// <summary>
        /// Getting File Path
        /// </summary>
        /// <param name="filePath">recieve file path</param>
        /// <returns>Return filepath</returns>
        public static string GetPath(string filePath)
        {
            string file = Path.Combine(filePath);
            if (File.Exists(file))
            {
                return file;
            }

            return DataEnum.DATA_NOT_EXIST.ToString();
        }
    }
}

