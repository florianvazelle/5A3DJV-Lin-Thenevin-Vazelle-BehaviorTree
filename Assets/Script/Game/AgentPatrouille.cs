using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script;

class AgentPatrouille : IAgent
{
    public AgentPatrouille(GameObject go, Vector3 src, Vector3 dst)
    {
        go.GetComponent<Transform>().position = src;
    }

    public void moveTo(Vector3 target) {

    }

    public bool Dectection() {

    }
    
    public void Fire() {

    }
}