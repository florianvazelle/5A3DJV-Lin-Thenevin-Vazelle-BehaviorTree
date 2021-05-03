using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionFire : IAction
{
    public void update(IAgent agent) {
        agent.Fire();
    }
}