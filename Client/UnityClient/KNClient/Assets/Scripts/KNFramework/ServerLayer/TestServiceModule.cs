using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KNFramework
{
    public class TestServiceModule : ServiceModule<TestServiceModule>
    {

        public override int Priority
        {
            get
            {
                return 6;
            }
        }

      

        public override void OnUpdate()
        {
            Debug.Log("1");
        }
    }
}
