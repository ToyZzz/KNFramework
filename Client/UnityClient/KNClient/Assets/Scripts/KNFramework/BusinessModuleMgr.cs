using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KNFramework
{
    public class BusinessModuleMgr : ServiceModule<BusinessModuleMgr>
    {
        public override int Priority
        {
            get { return 1; }
        }

        public override void OnUpdate()
        {
            
        }

        private class MessageObj
        {
            public string target;
            public string msg;
            public object[] args;
        }

        private Dictionary<string, BusinessModule> _businessModuleDic = new Dictionary<string, BusinessModule>();

        private Dictionary<string, List<MessageObj>> _messageCacheDic = new Dictionary<string, List<MessageObj>>();

        private Dictionary<string, EventTable> _preListenEventDic = new Dictionary<string, EventTable>();

        private string _domain;

        public T CreateBusinessModule<T>(object args = null) where T : BusinessModule
        {
            return (T)CreateBusinessModule(typeof(T).Name, args);
        }

        public BusinessModule CreateBusinessModule(string name, object args = null)
        {
            this.Log("CreateModule() name = " + name + ", args = " + args);

            if (_businessModuleDic.ContainsKey(name))
            {
                this.Log( Debuger.DebugColor.Red, "CreateModule() The Module<{0}> Has Existed!");
                return null;
            }

            BusinessModule module = null;
            Type type = Type.GetType(_domain + "." + name);
            if (type != null)
            {
                module = Activator.CreateInstance(type) as BusinessModule;
            }
            else
            {
                // module = new LuaModule(name);
            }
            _businessModuleDic.Add(name, module);

            //处理预监听的事件
            if (_preListenEventDic.ContainsKey(name))
            {
                EventTable mgrEvent = null;
                mgrEvent = _preListenEventDic[name];
                _preListenEventDic.Remove(name);

                module.SetEventTable(mgrEvent);
            }

            module.Create(args);

            //处理缓存的消息
            if (_messageCacheDic.ContainsKey(name))
            {
                List<MessageObj> list = _messageCacheDic[name];
                for (int i = 0; i < list.Count; i++)
                {
                    MessageObj msgobj = list[i];
                    module.HandleMessage(msgobj.msg, msgobj.args);
                }
                _messageCacheDic.Remove(name);
            }

            return module;
        }

        public BusinessModule GetModule(string name)
        {
            if (_businessModuleDic.ContainsKey(name))
            {
                return _businessModuleDic[name];
            }
            return null;
        }

        public ModuleEvent Event(string target, string type)
        {
            ModuleEvent evt = null;
            BusinessModule module = GetModule(target);
            if (module != null)
            {
                evt = module.Event(type);
            }
            else
            {
                //预创建事件
                EventTable table = GetPreEventTable(target);
                evt = table.GetEvent(type);
                // this.LogWarning("Event() target不存在！将预监听事件! target:{0}, event:{1}", target, type);
            }
            return evt;
        }

        private EventTable GetPreEventTable(string target)
        {
            EventTable table = null;
            if(!_preListenEventDic.TryGetValue(target, out table))
            {
                table = new EventTable();
                _preListenEventDic.Add(target, table);
            }
            return table;
        }

        public void SendMessage(string target,string msg, params object[] args)
        {
            BusinessModule module = GetModule(target);
            if (module != null)
            {
                module.HandleMessage(msg, args);
            }
        }
    }
}