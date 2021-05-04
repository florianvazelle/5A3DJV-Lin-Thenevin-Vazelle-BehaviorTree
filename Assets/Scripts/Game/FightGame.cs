using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Jeu de combat, on va avoir deux agent :
/// - un controlé par le BehaviorTree 
/// - un controlé par le joueur à l'aide de button (OnGui)
/// Chaque agent pourra se déplacer, attaquer et bloquer les coups
/// </summary>
public class FightGame : MonoBehaviour
{
    /// <summary>
    /// Structure pour représenter un agent dans l'inspecteur d'Unity
    /// Il est composé des données dont on aura besoin
    /// </summary>
    [System.Serializable]
    public struct Agent
    {
        public GameObject agentGO;
        public Animator animator;
        public AudioClip tokenGrabClip;
    }

    public List<Agent> agents;
    private AgentFight agentFight, player;
    private Selector rootSelector;

    void Start()
    {
        // On crée les deux AgentFight
        agentFight = new AgentFight(agents[0].agentGO, agents[0].animator, agents[0].tokenGrabClip);
        player = new AgentFight(agents[1].agentGO, agents[1].animator, agents[1].tokenGrabClip); // On va dire que l'agent 1 est le joueur

        /* Utilisation de l'API */
        
        Sequence blockSequence = new Sequence();
        blockSequence.Add(new Action(agentFight.Bleed));
        blockSequence.Add(new Action(agentFight.Block));

        Sequence unblockSequence = new Sequence();
        unblockSequence.Add(new ForceState<Action>(new Action(agentFight.UnBlock), State.FAILURE));

        Sequence punchSequence = new Sequence();
        punchSequence.Add(new Action(new Binder<AgentFight, State>(agentFight.Distance, player).Apply));
        punchSequence.Add(new Action(new Binder<AgentFight, State>(agentFight.Punch, player).Apply));

        Sequence walkSequence = new Sequence();
        walkSequence.Add(new Action(agentFight.GoForward));

        Sequence defaultSequence = new Sequence();
        defaultSequence.Add(new Action(agentFight.Idle));

        rootSelector = new Selector();
        rootSelector.Add(blockSequence);
        rootSelector.Add(unblockSequence);
        rootSelector.Add(punchSequence);
        rootSelector.Add(walkSequence);
        rootSelector.Add(defaultSequence);
    }

    void Update()
    {
        BehaviorTree.act(rootSelector);
    }

    /// <summary>
    /// Dans cette fonction on va retrouver les actions que le joueur peut réaliser
    /// </summary>
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

        if (GUI.Button(new Rect(25, 140, 100, 30), "UnBlock"))
        {
            player.UnBlock();
        }
    }
}
