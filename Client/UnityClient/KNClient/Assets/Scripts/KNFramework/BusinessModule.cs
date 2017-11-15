using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BusinessModule : ModuleBase
{
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
}
