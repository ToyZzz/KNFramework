using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleBase  {

    /// <summary>
    /// 调用创建
    /// </summary>
    public virtual void OnCreate()
    {

    }

    /// <summary>
    /// 调用释放
    /// </summary>
    public virtual void OnRelease()
    {
        // this.Log("On Release");
    }
}
