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
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void TestDebug()
    {
        this.Log(Debuger.DebugColor.Blue, "Test Log Value");
    }
}
