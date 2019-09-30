using System;
using System.IO;
using Assets.GameSystem.Constant;
using Assets.GameSystem.Constant.Enum;
using UnityEngine;
using Assets.GameSystem.Lib;
using GameSystem.Constant;
using GameSystem.Entity;
using TMPro;


namespace GameSystem.Service
{
    public class PreferencesService: MonoBehaviour
    {
        /// <summary>
        /// Load All Settings from file
        /// </summary>
        /// <returns>return settings</returns>
        /// <exception cref="ArgumentNullException">throw null exception if data not found</exception>
        public static GameSettings LoadSettings()
        {
            string file = PathConstants.GetPath(PathConstants.DATA_PATH+PathConstants.SETTING_FILE);
            if (!file.Equals(DataEnum.DATA_NOT_EXIST.ToString()))
            {
                string json = File.ReadAllText(file);
                GameSettings gameSettings = FileHelper<GameSettings>.JsonStringParserToObject(json, new GameSettings());
                return gameSettings;
            }

            GameSettings gameSetting = LoadDefaultGameSettings();
            
            File.WriteAllText(@""+PathConstants.DATA_PATH+PathConstants.SETTING_FILE, 
                FileHelper<GameSettings>.ObjectParserToJsonString(gameSetting));
           
            return gameSetting;
        }

        /// <summary>
        /// Write Settings to json file
        /// </summary>
        /// <param name="gameSettings">recieve GameaSettings Object</param>
        public static void WriteSettings(GameSettings gameSettings)
        {
            string json = FileHelper<GameSettings>.ObjectParserToJsonString(gameSettings);
            File.WriteAllText(PathConstants.DATA_PATH+PathConstants.SETTING_FILE,
                json);
        }

        public static float ConvertToUnityValue(float val)
        {
            return val / 100;
        }

        public static float ConvertToFOV(float val)
        {
            return val / 180;
        }

        private static GameSettings LoadDefaultGameSettings()
        {
           GameSettings gameSettings = new GameSettings();
           gameSettings.Volume = GameConstants.DEFAULT_VOLUME;
           gameSettings.Lighting = GameConstants.DEFAULT_LIGHTING;
           gameSettings.FieldOfView = GameConstants.DEFAULT_FOV;
           return gameSettings;
        }
    }
}