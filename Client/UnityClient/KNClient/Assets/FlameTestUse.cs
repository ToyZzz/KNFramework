using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KNFramework;

public class FlameTestUse : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        TestDebug();
        ServiceModuleMgr.CreateInstance(true, null);
        // TimerModule.CreateInstance();
        SerTimer.CreateModule();
        BusinessModuleMgr.CreateModule();
        OnServerModuleInitOk();
    }

    void OnServerModuleInitOk()
    {
        AModule a = BusinessModuleMgr.Instance.CreateBusinessModule<AModule>();
        BModule b = BusinessModuleMgr.Instance.CreateBusinessModule<BModule>();
        a.SendMessage();
        b.Event("onModuleEventB").Invoke("sdasd");
    }
	// Update is called once per frame
	void Update () {
		
	}

    private void TestDebug()
    {
        this.Log(Debuger.DebugColor.Blue, "Test Log Value");
    }
}
