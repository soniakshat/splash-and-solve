using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SplashAndSolve
{
    public class CustomLog
    {
        public const bool isShowLogs = true;

        public static void Log(string message)
        {
            Log(null, message);
        }

        public static void Log(string tag, string message)
        {
            if (!isShowLogs)
            {
                return;
            }

            if (string.IsNullOrEmpty(tag))
            {
                Debug.Log("ABC :: " + message);
            }
            else
            {
                Debug.Log("ABC [" + tag + "] :: " + message);
            }
        }

        public static void LogError(string message)
        {
            LogError(null, message);
        }

        public static void LogError(string tag, string message)
        {
            if (!isShowLogs)
            {
                return;
            }

            if (string.IsNullOrEmpty(tag))
            {
                Debug.LogError("ABC :: " + message);
            }
            else
            {
                Debug.LogError("ABC [" + tag + "] :: " + message);
            }
        }

        public static void LogWarning(string message)
        {
            LogWarning(null, message);
        }

        public static void LogWarning(string tag, string message)
        {
            if (!isShowLogs)
            {
                return;
            }

            if (string.IsNullOrEmpty(tag))
            {
                Debug.LogWarning("ABC :: " + message);
            }
            else
            {
                Debug.LogWarning("ABC [" + tag + "] :: " + message);
            }
        }
    }
}
