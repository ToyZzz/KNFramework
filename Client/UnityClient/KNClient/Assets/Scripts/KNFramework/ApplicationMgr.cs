using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KNFramework
{
    /// <summary>
    /// 程序运行类型枚举
    /// </summary>
    public enum ApplicationMode : uint
    {
        Debug = 1,
        Release = 2,
    }

    public class ApplicationMgr : MonoBehaviour
    {
        /// <summary>
        /// 程序运行类型
        /// </summary>
        public ApplicationMode m_applicationMode = ApplicationMode.Debug;

        private void Start()
        {
            ModuleMgr.CreateInstance(true);
            ModuleMgr.Instance.Init();
        }

        private void Update()
        {

        }

    }
}
