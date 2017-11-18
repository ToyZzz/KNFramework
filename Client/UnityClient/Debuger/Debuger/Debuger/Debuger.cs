using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KNFramework
{

    public class Debuger
    {
        public enum DebugColor : int
        {
            Red,
            Green,
            Blue,
            Gold,
        }

        public static string[] debugColorArray = new string[]
        {
        "ff4500",
        "7cfc00",
        "1e90ff",
        "ffd700"
        };

        public static bool EnableLog = true;

        public static bool EnableLogWithTime = true;

        public static bool EnableLogToFile = false;



        public static void Log(DebugColor debugColor, string TagName, string methodName, string msg, object context = null)
        {
            Log(debugColorArray[(int)debugColor], TagName, methodName, msg, context);
        }

        public static void Log(string debugColor, string TagName, string methodName, string msg, object context = null)
        {
            InternalLog(string.Format("<color=#{0}>{1}:{2}:{3}</color>", debugColor, TagName, methodName, msg), context);
        }

        public static void Log(DebugColor debugColor, string msg, object context = null)
        {
            Log(debugColorArray[(int)debugColor], msg, context);
        }

        public static void Log(string debugColor, string msg, object context = null)
        {
            InternalLog(string.Format("<color=#{0}>{1}</color>", debugColor, msg), context);
        }

        public static void Log(string msg, object context = null)
        {

        }

        private static void InternalLog(string msg, object context = null)
        {
            UnityEngine.Debug.Log(msg, (UnityEngine.Object)context);
        }

        public static void LogWarning()
        {

        }

        public static void LogError()
        {

        }
    }
}
