using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class AgentFight
{
    private Animator animator;
    private GameObject gameObject;
    private int hp;

    public Vector3 targetPos;
    public AgentFight(GameObject go, Animator animator)
    {
        this.gameObject = go;
        this.animator = animator;
        hp = 100;
    }

    public State Block()
    {
        
        if(newHP != oldHP)
        {
            return State.SUCCESS;
        }
        return State.FAILURE;
    }    
    public State Punch(AgentFight agent)
    {
        Transform transform = gameObject.GetComponent<Transform>();
        targetPos = GameObject.Find("Enemie").GetComponent<Transform>().position;

        float distance;
        if(transform.position.x > targetPos.x)
        {
            distance = transform.position.x - targetPos.x;
        }
        else
        {
            distance = targetPos.x - transform.position.x;
        }

        
        if ((distance) < 2)
        {
            //add animation
            agent.hp -= 10;
            return State.SUCCESS;
        }

        return State.FAILURE;
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