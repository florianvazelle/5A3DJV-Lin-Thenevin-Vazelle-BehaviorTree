using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiltrationGame : MonoBehaviour
{
    [System.Serializable]
    public struct Agent {
        public GameObject agentGO;
        public Vector3 src, dst;
    }

    public List<Agent> agents;
    private List<AgentPatrol> agentsPatrol;
    private List<Selector> rootSelectors;

    // Start is called before the first frame update
    void Start()
    {
        agentsPatrol = new List<AgentPatrol>();
        rootSelectors = new List<Selector>();

        // On crée un AgentPatrol
        for (var i = 0; i < agents.Count; i++)
        {
            agentsPatrol.Add(new AgentPatrol(agents[i].agentGO, agents[i].src, agents[i].dst));
            
            /* Utilisation de l'API */
            Sequence detectActionSequence = new Sequence();
            detectActionSequence.Add(new Action(agentsPatrol[i].Detection));
            detectActionSequence.Add(new Action(agentsPatrol[i].MoveToTarget));
            detectActionSequence.Add(new Delay<Action>(new Action(agentsPatrol[i].Fire)));

            Sequence defaultSequence = new Sequence();
            defaultSequence.Add(new Action(agentsPatrol[i].Patrol));

            rootSelectors.Add(new Selector());
            rootSelectors[i].Add(detectActionSequence);
            rootSelectors[i].Add(defaultSequence);
        }
    }

    // Update is called once per frame
    void Update()
    {   
        for (var i = 0; i < rootSelectors.Count; i++)
            BehaviorTree.act(rootSelectors[i]);
    }
}
