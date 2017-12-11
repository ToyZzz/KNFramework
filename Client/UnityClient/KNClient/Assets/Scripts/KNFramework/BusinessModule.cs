using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

namespace KNFramework
{
    public abstract class BusinessModule : ModuleBase
    {
        public BusinessModule()
        {
            OnCreate();
        }

        internal BusinessModule(string name)
        {
            _name = name;
            OnCreate();
        }

        private string _name;

        public string Name
        {
            get
            {
                if (_name == null)
                {
                    _name = this.GetType().Name;
                }
                return _name;
            }
        }
        private EventTable m_tblEvent;

        /// <summary>
        /// 实现抽象事件功能
        /// 可以像这样使用：obj.Event("onLogin").AddListener(...)        
        /// 事件的发送方法：this.Event("onLogin").Invoke(args)
        /// 而不需要在编码时先定义好，以提高模块的抽象程度
        /// 但是在模块内部的类不应该过于抽象，比如数据发生更新了，
        /// 在UI类这样使用：obj.onUpdate.AddListener(...)
        /// 这两种方法在使用形式上，保持了一致性！
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public ModuleEvent Event(string type)
        {
            return GetEventTable().GetEvent(type);
        }

        internal void SetEventTable(EventTable mgrEvent)
        {
            m_tblEvent = mgrEvent;
        }

        /// <summary>
        /// 当模块收到消息后，对消息进行一些处理
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="args"></param>
        internal void HandleMessage(string msg, object[] args)
        {
            // this.Log("HandleMessage() msg:{0}, args:{1}", msg, args);
            this.Log(Debuger.DebugColor.Green, this.GetType().Name);
            MethodInfo mi = this.GetType().GetMethod(msg, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            if (mi != null)
            {
                mi.Invoke(this, BindingFlags.NonPublic, null, args, null);
            }
            else
            {
                OnModuleMessage(msg, args);
            }
        }

        protected virtual void OnModuleMessage(string msg, object[] args)
        {
            this.Log( Debuger.DebugColor.Gold, "OnModuleMessage() msg:{0}, args:{1}" + msg);
        }

        /// <summary>
        /// 调用它以创建模块
        /// </summary>
        /// <param name="args"></param>
        public virtual void Create(object args = null)
        {
            this.Log("Create() args = " + args);
        }

        protected EventTable GetEventTable()
        {
            if (m_tblEvent == null)
            {
                m_tblEvent = new EventTable();
            }
            return m_tblEvent;
        }
    }
}