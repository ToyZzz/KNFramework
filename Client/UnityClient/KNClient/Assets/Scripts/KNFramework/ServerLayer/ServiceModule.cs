using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KNFramework
{
    public abstract class ServiceModule<T> : MonoBehaviour ,IModuleBase where T : ServiceModule<T>
    {
        protected static T _instance = null;

        protected string _moduleName;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    Debug.Log("Error");
                }
                return _instance;
            }
        }

        public abstract int Priority { get; }

        public string ModuleName
        {
            get
            {
                if (_instance._moduleName == null)
                {
                    _instance._moduleName = _instance.GetType().Name;
                }
                return _instance._moduleName;
            }
        }

        public static T CreateModule(bool dontDestroyOnLoad, Transform fatherTrans)
        {
            if (_instance != null)
            {
                Debug.Log("todo");
                return null;
            }
            GameObject go = new GameObject();
            if (fatherTrans)
            {
                go.transform.SetParent(fatherTrans, false);
                go.transform.localPosition = new Vector3(0, 0, 0);
            }
            _instance = go.AddComponent<T>();
            _instance._moduleName = _instance.GetType().Name;
            go.name = _instance._moduleName;
            if (dontDestroyOnLoad)
            {
                GameObject.DontDestroyOnLoad(go);
            }
            _instance.OnCreateModule();
            return _instance;
        }

        public virtual void OnCreateModule()
        {
            this.Log(_moduleName + " is Create");
            ServiceModuleMgr.Instance.OnServiceModuleInit<T>(_instance);
        }

        public static void ReleaseModule()
        {
            if (_instance != null)
            {
                _instance.OnReleaseModule();
                GameObject.Destroy(_instance.gameObject);
                _instance = null;
            }
        }

        public virtual void OnReleaseModule()
        {
            this.Log(_instance.GetType().Name + " is Release");
            ServiceModuleMgr.Instance.OnServiceModuleInit<T>(_instance);
        }

        public abstract void OnUpdate();
    }
}
