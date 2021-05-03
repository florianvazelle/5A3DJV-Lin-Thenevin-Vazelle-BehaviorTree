using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPatrouille : IAction
{
    public void update(IAgent agent) {
        agent.moveTo();
    }
}