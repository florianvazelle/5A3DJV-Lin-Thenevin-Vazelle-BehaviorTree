using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class AgentPatrol
{
    private GameObject gameObject;
    private Vector3 src, dst;
    private float moveSpeed = 0.01f;

    public bool hasSeenPlayer;
    public Vector3 targetDetected;

    public AgentPatrol(GameObject go, Vector3 src, Vector3 dst)
    {
        this.gameObject = go;
        Transform transform = go.GetComponent<Transform>();
        transform.position = src;

        this.src = src;
        this.dst = dst;
        transform.Rotate(new Vector3(0, Vector3.Normalize(dst - transform.position).x * 90, 0));
    
        this.hasSeenPlayer = false;
    }

    public State MoveToTarget() {
        Transform transform = gameObject.GetComponent<Transform>();
        transform.position = Vector3.Lerp(transform.position, targetDetected, moveSpeed);
        
        return State.SUCCESS;
    }

    public State Detection() {
        Transform transform = gameObject.GetComponent<Transform>();
        FieldOfView fov = gameObject.GetComponent<FieldOfView>();
        
        Vector3 playerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        playerPos = new Vector3(playerPos.x, 0, playerPos.z);

        // find angle to player
        Vector3 lookDir = Vector3.Normalize(dst - transform.position); 
        Vector3 playerDir = (playerPos - transform.position);
        float playerAngle = Vector3.Angle(playerDir, lookDir);

        // find distance to player
        float playerDist = Vector3.Distance(playerPos, transform.position);

        if (playerAngle <= fov.angle_fov && playerDist <= fov.dist_max)
        {
            fov.audioData.Play(0);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, playerDir, playerDist);
            if (!hit) // pas de mur
            {
                //Debug.Log("test");
                hasSeenPlayer = true;
                targetDetected = playerPos;
                fov.material.SetColor("_Color", Color.red);
                return State.SUCCESS;
            }
        }

        hasSeenPlayer = false;
        fov.material.SetColor("_Color", Color.white);
        return State.FAILURE;
    }
    
    public State Fire() {
            FieldOfView fov = gameObject.GetComponent<FieldOfView>();
            //fov.material.SetColor("_Color", Color.black);
        return State.SUCCESS;
    }

    public State Patrol() {
        Transform transform = gameObject.GetComponent<Transform>();

        if (dst.x - 0.1f <= transform.position.x && transform.position.x <= dst.x + 0.1f &&
            dst.z - 0.1f <= transform.position.z && transform.position.z <= dst.z + 0.1f)
        {
            Vector3 tmp = dst;
            dst = src;
            src = tmp;

            // update rotation
            transform.Rotate(new Vector3(0, Vector3.Normalize(dst - transform.position).x * 180, 0));
        }

        transform.position = Vector3.Lerp(transform.position, dst, moveSpeed);
        return State.SUCCESS;
    }
}