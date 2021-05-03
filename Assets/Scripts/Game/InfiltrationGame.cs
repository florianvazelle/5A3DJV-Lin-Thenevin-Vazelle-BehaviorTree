using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiltrationGame : MonoBehaviour
{
    public GameObject agentPatrouille;
    public Vector3 src, dst;
    private AgentPatrol agent;
    private Selector rootSelector;

    // Start is called before the first frame update
    void Start()
    {
        // On crée un AgentPatrol
        agent = new AgentPatrol(agentPatrouille, src, dst);
        
        /* Utilisation de l'API */
        Sequence detectActionSequence = new Sequence();
        detectActionSequence.AddAction(new Action(agent.Detection));
        detectActionSequence.AddAction(new Action(agent.MoveToTarget));
        detectActionSequence.AddAction(new Action(agent.Fire));

        Sequence defaultSequence = new Sequence();
        defaultSequence.AddAction(new Action(agent.Patrol));

        rootSelector = new Selector();
        rootSelector.AddAction(detectActionSequence);
        rootSelector.AddAction(defaultSequence);
    }

    // Update is called once per frame
    void Update()
    {   
        BehaviorTree.act(in rootSelector);
    }
}
