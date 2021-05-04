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

    public List<Agent> agents;
    private AgentFight agentFight, player;
    private Selector rootSelector;

    // Start is called before the first frame update
    void Start()
    {
        // On crée un AgentFight
        agentFight = new AgentFight(agents[0].agentGO);
        player = new AgentFight(agents[1].agentGO); // On va dire que l'agent 1 est le joueur

        /* Utilisation de l'API */
        Sequence punchSequence = new Sequence();
        // detectActionSequence.Add(new Action(agentFight.Detection));
        // detectActionSequence.Add(new Action(agentFight.MoveToTarget));
        // detectActionSequence.Add(new Delay<Action>(new Action(agentFight.Fire), 2));
        punchSequence.Add(new Action(new Binder<AgentFight, State>(agentFight.Punch, player).Apply));

        Sequence walkSequence = new Sequence();
        walkSequence.Add(new Action(agentFight.GoForward));

        Sequence defaultSequence = new Sequence();
        defaultSequence.Add(new Action(agentFight.Idle));

        rootSelector = new Selector();
        // rootSelector.Add(detectActionSequence);
        rootSelector.Add(walkSequence);
        rootSelector.Add(defaultSequence);
    }

    // Update is called once per frame
    void Update()
    {
        BehaviorTree.act(rootSelector);
    }
}
