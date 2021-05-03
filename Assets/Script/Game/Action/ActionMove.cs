using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMove : IAction
{
    public bool verify(IAgent agent) {
        return true; // TODO : check obstacle
    }

    public void update(IAgent agent) {
        agent.moveTo();
    }
}