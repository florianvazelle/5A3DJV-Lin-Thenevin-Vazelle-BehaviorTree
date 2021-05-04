using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class AgentFight
{
    private Animator animator;
    private GameObject gameObject;
    private int hp;

    public AgentFight(GameObject go, Animator animator)
    {
        this.gameObject = go;
        this.animator = animator;
    }

    public State Idle()
    {
        animator.Play("Idle");
        return State.SUCCESS;
    }

    public State GoForward()
    {
        animator.SetBool("Walk Forward", false);
        return State.SUCCESS;
    }
}