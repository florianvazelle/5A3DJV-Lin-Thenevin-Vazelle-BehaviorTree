using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMove : IAction
{

    public void update(IAgent agent) {
        agent.moveTo();
    }
}