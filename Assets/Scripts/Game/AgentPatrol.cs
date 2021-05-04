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

    private AudioClip tokenGrabClip;

    private AudioSource tokenGrab;

    public AudioSource TokenGrab
    {
        get { return tokenGrab; }
    }

    public AgentPatrol(GameObject go, Vector3 src, Vector3 dst)
    {
        this.gameObject = go;
        Transform transform = go.GetComponent<Transform>();
        transform.position = src;

        this.src = src;
        this.dst = dst;
        SetRotation(dst);

        this.hasSeenPlayer = false;

        FieldOfView fov = gameObject.GetComponent<FieldOfView>();
        this.tokenGrab = AddAudio(fov.tokenGrabClip, false, false, 0.5f);
    }

    private void SetRotation(Vector3 target)
    {
        Transform transform = gameObject.GetComponent<Transform>();
        Vector3 targetDir = (target - transform.position);

        float targetAngle = Vector3.SignedAngle(targetDir, Vector3.forward, -Vector3.up);
        transform.rotation = Quaternion.Euler(0, targetAngle, 0);
    }


    public virtual AudioSource AddAudio(AudioClip clip, bool isLoop, bool isPlayAwake, float vol)
    {
        AudioSource newAudio = gameObject.AddComponent<AudioSource>() as AudioSource;
        newAudio.clip = clip;
        newAudio.loop = isLoop;
        newAudio.playOnAwake = isPlayAwake;
        newAudio.volume = vol;
        return newAudio;
    }

    public State MoveToTarget() {
        Transform transform = gameObject.GetComponent<Transform>();

        Vector3 playerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        playerPos = new Vector3(playerPos.x, 0, playerPos.z);

        transform.position = Vector3.Lerp(transform.position, targetDetected, moveSpeed);
        SetRotation(playerPos);
        
        return State.SUCCESS;
    }

    public State Detection() {
        Transform transform = gameObject.GetComponent<Transform>();
        FieldOfView fov = gameObject.GetComponent<FieldOfView>();
        
        Vector3 playerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        playerPos = new Vector3(playerPos.x, 0, playerPos.z);

        // find angle to player
        Vector3 target = dst;
        if (hasSeenPlayer) {
            target = targetDetected;
        }
        Vector3 lookDir = Vector3.Normalize(target - transform.position); 
        Vector3 playerDir = (playerPos - transform.position);
        float playerAngle = Vector3.Angle(playerDir, lookDir);

        // find distance to player
        float playerDist = Vector3.Distance(playerPos, transform.position);

        if (playerAngle <= fov.angle_fov * 1.25f && playerDist <= fov.dist_max * 1.25f)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, playerDir, playerDist);
            if (!hit) // pas de mur
            {
                hasSeenPlayer = true;
                targetDetected = playerPos - Vector3.Normalize(playerDir);
                fov.newMaterial.SetColor("_Color", Color.red);
                return State.SUCCESS;
            }
        }

        hasSeenPlayer = false;
        fov.newMaterial.SetColor("_Color", Color.white);
        return State.FAILURE;
    }
    
    public State Fire() {
        FieldOfView fov = gameObject.GetComponent<FieldOfView>();
        tokenGrab.PlayOneShot(fov.tokenGrabClip);

        return State.SUCCESS;
    }

    public State Patrol() {
        Transform transform = gameObject.GetComponent<Transform>();

        var margin = 0.1f;
        if (dst.x - margin <= transform.position.x && transform.position.x <= dst.x + margin &&
            dst.z - margin <= transform.position.z && transform.position.z <= dst.z + margin)
        {
            Vector3 tmp = dst;
            dst = src;
            src = tmp;
        }

        transform.position = Vector3.Lerp(transform.position, dst, moveSpeed);
        SetRotation(dst);
        
        return State.SUCCESS;
    }
}