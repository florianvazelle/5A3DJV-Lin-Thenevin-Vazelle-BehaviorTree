using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe pour représenter un agent dans notre jeu de combat
/// </summary>
class AgentFight
{
    private Animator animator;
    private GameObject gameObject;
    private GameObject shield;
    private int hp;
    private int oldHp;

    private const float minDistToPunch = 2.5f;

    public AgentFight(GameObject go, Animator animator)
    {
        this.gameObject = go;
        this.animator = animator;
        this.shield = getShield();
        hp = 100;
        oldHp = 100;
    }

    /// <summary>
    /// Helper pour récupérer la distance entre les deux joueurs
    /// </summary>
    /// <params name="agent">
    /// L'agent avec lequel on veut avoir la distance
    /// </params>
    private float GetDistance(AgentFight agent)
    {
        Transform transform = gameObject.GetComponent<Transform>();
        Transform targetTransform = agent.gameObject.GetComponent<Transform>();

        return Vector3.Distance(targetTransform.position, transform.position);
    }

    /// <summary>
    /// Action de défense, on va lancer l'animation de blocage des coups si on a perdu de la vie
    /// </summary>
    public State Block()
    {
        if (hp != oldHp)
        {
            oldHp = hp;
            return State.SUCCESS;
        }
        return State.FAILURE;
    }

    /// <summary>
    /// Condition de distance, retourne SUCCESS si le joueur est proche de notre agent
    /// </summary>
    /// <params name="agent">
    /// L'agent avec lequel on veut avoir la distance
    /// </params>
    public State Distance(AgentFight agent)
    {
        float distance = GetDistance(agent);
        return (distance < minDistToPunch) ? State.SUCCESS : State.FAILURE;
    }

    /// <summary>
    /// Action d'attaque, on lance l'animation d'attaque si le joueur est toujours a porté 
    /// </summary>
    public State Punch(AgentFight agent)
    {   
        // On vérifie que l'on a aps activé d'autre animation
        animator.SetBool("Walk Forward", false);

        // On refait le calcule de distance
        float distance = GetDistance(agent);
        if (distance < minDistToPunch)
        {
            // Si l'agent est toujours a porté
            // On lance l'animation
            animator.SetTrigger("PunchTrigger");
            // On baisse les hp de l'adversaire
            agent.hp -= 10;
            return State.SUCCESS;
        }

        return State.FAILURE;
    }

    /// <summary>
    /// Action par défaut, l'agent attend, on lance l'animation Idle 
    /// </summary>
    public State Idle()
    {
        animator.Play("Idle");
        return State.SUCCESS;
    }

    /// <summary>
    /// Action de déplacement, on lance l'animation de marche 
    /// </summary>
    public State GoForward()
    {
        animator.SetBool("Walk Forward", true);
        // Petit trik pour s'assurer que l'agent reste sur l'axe X
        Transform transform = gameObject.GetComponent<Transform>();
        transform.position = new Vector3(transform.position.x, 0, 0);
        return State.SUCCESS;
    }

    private GameObject getShield()
    {
        GameObject ChildGameObject = gameObject.transform.GetChild(0).gameObject;
        //Debug.Log(ChildGameObject.transform.name);
		GameObject  SubChildGameObject = ChildGameObject.transform.GetChild(0).gameObject;
        return SubChildGameObject;
    }
}