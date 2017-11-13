using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DebugModuleExtension
{
    public static void Log(this object obj, string message = "")
    {
        Debug.Log(message);
    }
}
