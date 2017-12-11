using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace KNFramework
{

    public class EventTable
    {
        private Dictionary<string, ModuleEvent> _moduleEventDic;

        public ModuleEvent GetEvent(string type)
        {
            if (_moduleEventDic == null)
            {
                _moduleEventDic = new Dictionary<string, ModuleEvent>();
            }
            if (!_moduleEventDic.ContainsKey(type))
            {
                _moduleEventDic.Add(type, new ModuleEvent());
            }
            return _moduleEventDic[type];
        }

        public void Clear()
        {
            if(_moduleEventDic!= null)
            {
                foreach(var moduleEvent in _moduleEventDic)
                {
                    moduleEvent.Value.RemoveAllListeners();
                }
                _moduleEventDic.Clear();
            }
        }
    }

    public class ModuleEvent : UnityEvent<object>
    {

    }

    public class ModuleEvent<T> : UnityEvent<T>
    {

    }
}