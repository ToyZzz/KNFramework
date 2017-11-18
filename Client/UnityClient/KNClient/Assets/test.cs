using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KNFramework;
using System;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        ServiceModuleMgr.CreateInstance(true);
        // Debug.LogError("<color=#00ffff>aaaaaaa</color>");
        this.Log(Debuger.DebugColor.Gold, "Test");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

