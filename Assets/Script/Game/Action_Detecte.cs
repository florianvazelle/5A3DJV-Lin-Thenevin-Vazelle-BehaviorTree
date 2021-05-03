using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script.API
{
    public class Action_Detecte : IAction
    {
        public bool verify(IAgent agent) {
            return true;
        }

        public void update(IAgent agent) {
            
        }
    }
}