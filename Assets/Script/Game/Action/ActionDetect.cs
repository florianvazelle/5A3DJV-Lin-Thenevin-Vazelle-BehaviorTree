using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionDetect : IAction
{
    public bool verify(IAgent agent) {
        return agent.Dectection();
    }

    public void update(IAgent agent) {
        // do nothing
    }
}