using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPatrouille : IAction
{
    public bool verify(IAgent agent) {
        return true;
    }

    public void update(IAgent agent) {
        agent.moveTo();
    }
}