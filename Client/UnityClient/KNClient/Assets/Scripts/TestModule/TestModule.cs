using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KNFramework;

public class TestModule:BusinessModule
{
    
}

public class AModule : BusinessModule
{
    public override void OnCreate()
    {
        base.OnCreate();
        this.Log(Debuger.DebugColor.Gold, "OnCreate");
    }

    public void SendMessage()
    {
        BusinessModuleMgr.Instance.SendMessage("BModule", "OnGetMessage", "ssss", 5);
        BusinessModuleMgr.Instance.SendMessage("BModule", "OnGetMessage2", "ssss", 2);

        BusinessModuleMgr.Instance.Event("BModule", "onModuleEventB").AddListener(OnGetMes);
    }

    public void OnGetMes(object name)
    {
        this.Log(Debuger.DebugColor.Blue, name.ToString());
    }
}

public class BModule : BusinessModule
{
    public void OnGetMessage(string args1, int args2)
    {
        this.Log(Debuger.DebugColor.Blue, "GetMessage");
    }

    protected override void OnModuleMessage(string msg, object[] args)
    {
        base.OnModuleMessage(msg, args);

    }
}