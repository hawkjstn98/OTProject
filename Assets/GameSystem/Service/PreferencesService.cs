using System;
using System.IO;
using Assets.GameSystem.Constant;
using Assets.GameSystem.Constant.Enum;
using UnityEngine;
using Assets.GameSystem.Entity;
using Assets.GameSystem.Lib;


namespace Assets.GameSystem.Service
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
            throw new ArgumentNullException("Data Not Found");
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
    }
}