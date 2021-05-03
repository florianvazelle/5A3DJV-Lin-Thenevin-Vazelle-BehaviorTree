using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class AgentPatrouille : IAgent
{
    public AgentPatrouille(GameObject go, Vector3 src, Vector3 dst)
    {
        go.GetComponent<Transform>().position = src;
    }

    public void moveTo(Vector3 target) {

    }

    public bool Dectection() {
        return false;
    }
    
    public void Fire() {

    }
}