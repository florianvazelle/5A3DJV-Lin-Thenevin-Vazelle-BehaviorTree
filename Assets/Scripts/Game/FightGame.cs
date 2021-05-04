using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightGame : MonoBehaviour
{
    [System.Serializable]
    public struct Agent
    {
        public GameObject agentGO;
        public Animator animator;
    }

    public List<Agent> agents;
    private AgentFight agentFight, player;
    private Selector rootSelector;

    // Start is called before the first frame update
    void Start()
    {
        // On crée un AgentFight
        agentFight = new AgentFight(agents[0].agentGO, agents[0].animator);
        player = new AgentFight(agents[1].agentGO, agents[1].animator); // On va dire que l'agent 1 est le joueur

        /* Utilisation de l'API */
        Sequence BlockSequence = new Sequence();
        BlockSequence.Add(new Action(agentFight.Block));

        Sequence punchSequence = new Sequence();
        // detectActionSequence.Add(new Action(agentFight.Detection));
        // detectActionSequence.Add(new Action(agentFight.MoveToTarget));
        // detectActionSequence.Add(new Delay<Action>(new Action(agentFight.Fire), 2));
        punchSequence.Add(new Action(new Binder<AgentFight, State>(agentFight.Distance, player).Apply));
        punchSequence.Add(new Action(new Binder<AgentFight, State>(agentFight.Punch, player).Apply));

        Sequence walkSequence = new Sequence();
        walkSequence.Add(new Action(agentFight.GoForward));

        Sequence defaultSequence = new Sequence();
        defaultSequence.Add(new Action(agentFight.Idle));

        rootSelector = new Selector();
        // rootSelector.Add(detectActionSequence);
        rootSelector.Add(punchSequence);
        rootSelector.Add(walkSequence);
        rootSelector.Add(defaultSequence);
    }

    // Update is called once per frame
    void Update()
    {
        BehaviorTree.act(rootSelector);
    }

    void OnGUI()
    {
        if (GUI.RepeatButton(new Rect(25, 20, 100, 30), "Walk Forward"))
        {
            agents[1].animator.SetBool("Walk Forward", true);
        }
        else
        {
            agents[1].animator.SetBool("Walk Forward", false);
        }

        if (GUI.RepeatButton(new Rect(25, 50, 100, 30), "Walk Backward"))
        {
            agents[1].animator.SetBool("Walk Backward", true);
        }
        else
        {
            agents[1].animator.SetBool("Walk Backward", false);
        }

        if (GUI.Button(new Rect(25, 80, 100, 30), "Punch"))
        {
            player.Punch(agentFight);
        }

        if (GUI.Button(new Rect(25, 110, 100, 30), "Block"))
        {
            player.Block();
        }
    }
}
