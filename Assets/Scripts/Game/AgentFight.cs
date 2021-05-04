using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class AgentFight
{
    private GameObject gameObject;
    private int hp;

    public AgentFight(GameObject go)
    {
        this.gameObject = go;
    }

    public State Idle()
    {
        Animation anim = gameObject.GetComponent<Animation>();
        animator.Play("Idle");
        return State.SUCCESS;
    }

    public State GoForward()
    {
        Animation anim = gameObject.GetComponent<Animation>();
        animator.SetBool("Walk Forward", false);
        return State.SUCCESS;
    }
}