using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using Assets.GameSystem.Constant.Enum;
using UnityEngine;

namespace Assets.GameSystem.Lib
{
    public abstract class FileHelper<T>
    {
        
        public static T JsonStringParserToObject(string asd , T obj)
        {
            if (null != obj)
            {
                obj = JsonUtility.FromJson<T>(asd);
                return obj;
            }
            else
            {
                throw new ArgumentNullException("Object is null");
            }
        }

        public static string ObjectParserToJsonString(T obj)
        {
            string json = JsonUtility.ToJson(obj);
            return json;
        }
        
        /// <summary>
        /// Returns True If File Exist
        /// </summary>
        /// <param name="file"></param>
        /// <returns>true if Data Exist, False If Data Not Exist</returns>
        public static bool FileExist(string file)
        {
            return !DataEnum.DATA_NOT_EXIST.ToString().Equals(file);
        }
    }
}