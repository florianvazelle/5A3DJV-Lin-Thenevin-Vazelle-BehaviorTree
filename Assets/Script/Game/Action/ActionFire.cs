using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionFire : IAction
{
    public bool verify(IAgent agent) {
        return true; // TODO : check munitions
    }

    public void update(IAgent agent) {
        agent.Fire();
    }
}