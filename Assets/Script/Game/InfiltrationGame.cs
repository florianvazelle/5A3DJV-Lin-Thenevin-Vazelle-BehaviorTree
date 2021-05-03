using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiltrationGame : MonoBehaviour
{
    public GameObject agentPatrouille;
    public Vector3 src, dst;
    private IAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = new AgentPatrouille(agentPatrouille, src, dst);
    }

    // Update is called once per frame
    void Update()
    {
        // BehaviorTree.act(agent);
    }
}
