using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightGame : MonoBehaviour
{
    [System.Serializable]
    public struct Agent
    {
        public GameObject agentGO;
    }

    public Agent agent;
    private AgentFight agentFight;
    private Selector rootSelector;

    // Start is called before the first frame update
    void Start()
    {
        // On crée un AgentFight
        agentFight = new AgentFight(agent.agentGO);

        /* Utilisation de l'API */
        // Sequence detectActionSequence = new Sequence();
        // detectActionSequence.Add(new Action(agentFight.Detection));
        // detectActionSequence.Add(new Action(agentFight.MoveToTarget));
        // detectActionSequence.Add(new Delay<Action>(new Action(agentFight.Fire), 2));

        // Sequence defaultSequence = new Sequence();
        // defaultSequence.Add(new Action(agentFight.Patrol));

        rootSelector = new Selector();
        // rootSelector.Add(detectActionSequence);
        // rootSelector.Add(defaultSequence);
    }

    // Update is called once per frame
    void Update()
    {
        BehaviorTree.act(rootSelector);
    }
}
