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
        
        Sequence detectSequence = new Sequence();
        detectSequence.AddAction(new ActionDetect());
        detectSequence.AddAction(new AlwaysFalse());
    }

    // Update is called once per frame
    void Update()
    {
        // BehaviorTree.act(agent);
    }
}
