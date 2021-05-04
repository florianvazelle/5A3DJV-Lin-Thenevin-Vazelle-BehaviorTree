using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class AgentFight
{
    private Animator animator;
    private GameObject gameObject;
    private int hp;
    private int oldHp;

    public Vector3 targetPos;
    public AgentFight(GameObject go, Animator animator)
    {
        this.gameObject = go;
        this.animator = animator;
        hp = 100;
        oldHp = 100;
    }

    public State Block()
    {
        
        if(hp != oldHp)
        {
            oldHp = hp;
            return State.SUCCESS;
        }
        return State.FAILURE;
    }

    private float GetDistance(AgentFight agent)
    {
        Transform transform = gameObject.GetComponent<Transform>();
        Transform targetTransform = agent.gameObject.GetComponent<Transform>();

        return Vector3.Distance(targetTransform.position, transform.position);
    }

    const float minDistToPunch = 2.5f;

    public State Distance(AgentFight agent)
    {
        float distance = GetDistance(agent);
        Debug.Log(distance);
        return (distance < minDistToPunch) ? State.SUCCESS : State.FAILURE;
    }

    public State Punch(AgentFight agent)
    {
        animator.SetBool("Walk Forward", false);

        float distance = GetDistance(agent);

        if (distance < minDistToPunch)
        {
            //add animation
            animator.SetTrigger("PunchTrigger");
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
        animator.SetBool("Walk Forward", true);
        Transform transform = gameObject.GetComponent<Transform>();
        // transform.position = new Vector3(0, transform.position.y, transform.position.z);
        return State.SUCCESS;
    }
}