using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
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
    }
}