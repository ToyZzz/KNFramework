using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KNFramework
{
    public interface IModuleBase
    {
        int Priority { get; }

        string ModuleName { get; }

        void OnUpdate();
    }
}
