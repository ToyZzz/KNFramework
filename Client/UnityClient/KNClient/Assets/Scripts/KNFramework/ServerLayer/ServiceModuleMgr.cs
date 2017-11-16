using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KNFramework
{
    public class ServiceModuleMgr : MonoSingleton<ServiceModuleMgr>
    {
        /// <summary>
        /// 自助创建的服务层模块
        /// </summary>
        private Dictionary<string, IModuleBase> _serviceModuleDic = new Dictionary<string, IModuleBase>();

        private int _onUpdateLinkedListCount = 0;

        private LinkedList<IModuleBase> _onUpdateLinkedList = new LinkedList<IModuleBase>();

        private void Update()
        {
            if (_onUpdateLinkedListCount > 0)
            {
                foreach (var module in _onUpdateLinkedList)
                {
                    module.OnUpdate();
                }
            }
        }

        /// <summary>
        /// 创建时注册
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tInstance"></param>
        public void OnServiceModuleInit<T>(T tInstance) where T : IModuleBase
        {
            if (tInstance.Priority == 0)
            {
                return;
            }
            bool insertOk = false;
            foreach (var module in _onUpdateLinkedList)
            {
                if (module.Priority <= tInstance.Priority)
                {
                    _onUpdateLinkedList.AddBefore(_onUpdateLinkedList.Find(module), tInstance);
                    _onUpdateLinkedListCount += 1;
                    insertOk = true;
                    break;
                }
            }
            if (!insertOk)
            {
                _onUpdateLinkedListCount += 1;
                _onUpdateLinkedList.AddLast(tInstance);
            }
        }

        /// <summary>
        /// 释放时移除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tInstance"></param>
        public void OnServiceModuleRelease(IModuleBase module)
        {
            _serviceModuleDic.Remove(module.ModuleName);
            if (module.Priority > 0)
            {
                _onUpdateLinkedList.Remove(module);
                _onUpdateLinkedListCount -= 1;
            }
        }
    }
}
