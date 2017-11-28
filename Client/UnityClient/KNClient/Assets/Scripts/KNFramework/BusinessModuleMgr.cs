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
            // throw new NotImplementedException();
        }
    }
}