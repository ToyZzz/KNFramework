using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace KNFramework {
    public abstract class ServiceModule<T> :MonoBehaviour where T : MonoSingleton<T>
    {
        protected static T _instance = null;

        public static T Instance
        {
            get
            {
                if(_instance == null)
                {
                    Debug.Log("Error");
                }
                return _instance;
            }
        }

        public static T CreateModule(bool dontDestroyOnLoad)
        {

        }
    }
}
