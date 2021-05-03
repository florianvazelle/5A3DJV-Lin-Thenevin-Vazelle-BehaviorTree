using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class AgentPatrouille : IAgent
{
    private GameObject gameObject;
    private Vector3 src, dst;
    private float moveSpeed = 0.1f;

    public AgentPatrouille(GameObject go, Vector3 src, Vector3 dst)
    {
        go.GetComponent<Transform>().position = src;
    }

    public void moveTo(Vector3 target) {
        Transform transform = gameObject.GetComponent<Transform>();
        if (transform.position == dst) {
            Vector3 tmp = dst;
            dst = src;
            src = tmp;
        }

        transform.position = Vector3.Lerp(transform.position, dst, moveSpeed);
    }

    public bool Dectection() {
        return false;
    }
    
    public void Fire() {
        // do nothing
    }
}