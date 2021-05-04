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
        anim.Play("idle");
        return State.SUCCESS;
    }

    public State GoForward()
    {
        Animation anim = gameObject.GetComponent<Animation>();
        anim.Play("walk");
        return State.SUCCESS;
    }
}