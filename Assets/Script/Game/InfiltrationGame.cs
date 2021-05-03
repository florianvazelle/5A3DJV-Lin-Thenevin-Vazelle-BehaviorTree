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
        
        Selector detectSelector = new Selector();
        detectSelector.AddAction(new ActionDetect());
        detectSelector.AddAction(new AlwaysFalse());

        Selector actionSelector = new Selector();
        actionSelector.AddAction(new ActionMove());
        actionSelector.AddAction(new ActionFire());

        Selector defaultSelector = new Selector();
        defaultSelector.AddAction(new ActionPatrouille());

        List<Selector> selectors = new List<Selector>() {
            detectSelector,
            actionSelector,
            defaultSelector
        };
    }

    // Update is called once per frame
    void Update()
    {   
        // BehaviorTree.act(agent);
    }
}
