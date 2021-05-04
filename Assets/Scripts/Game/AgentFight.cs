using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe pour représenter un agent dans notre jeu de combat
/// </summary>
class AgentFight
{
    private const float minDistToPunch = 2.5f;

    private Animator animator;
    private GameObject gameObject, shield;
    private int hp, oldHp;
    private int numBlock;
    public AudioSource tokenGrab;
    public AudioClip m_tokenGrabClip;

    public AgentFight(GameObject go, Animator animator, AudioClip tokenGrabClip)
    {
        this.gameObject = go;
        this.animator = animator;
        this.shield = GetShield();
        this.hp = this.oldHp = 100;
        this.tokenGrab = AddAudio(tokenGrabClip, false, false, 0.5f);
        m_tokenGrabClip = tokenGrabClip;
    }
    
    private AudioSource AddAudio(AudioClip clip, bool isLoop, bool isPlayAwake, float vol)
    {
        AudioSource newAudio = gameObject.AddComponent<AudioSource>() as AudioSource;
        newAudio.clip = clip;
        newAudio.loop = isLoop;
        newAudio.playOnAwake = isPlayAwake;
        newAudio.volume = vol;
        return newAudio;
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
    /// Helper pour récupérer le GameObject correspondant au bouclier
    /// </summary>
    private GameObject GetShield()
    {
        GameObject ChildGameObject = gameObject.transform.GetChild(0).gameObject;
        GameObject SubChildGameObject = ChildGameObject.transform.GetChild(0).gameObject;
        return SubChildGameObject;
    }

    /// <summary>
    /// Condition de perte de vie, retourne SUCCESS si l'agent a perdu de la vie
    /// </summary>
    public State Bleed()
    {
        return (hp != oldHp) ? State.SUCCESS : State.FAILURE;
    }

    /// <summary>
    /// Action de défense, on va lancer l'animation de blocage des coups
    /// </summary>
    public State Block()
    {
        animator.ResetTrigger("PunchTrigger");
        animator.Play("Idle");

        // On active le bouclier
        shield.SetActive(true);

        numBlock++;
        if (numBlock > 500)
        {
            numBlock = 0;
            
            // On actualise nos hp
            oldHp = hp;
        }

        return State.SUCCESS;
    }

    /// <summary>
    /// Action de un-défense, on va enlever le bouclier
    /// </summary>
    public State UnBlock()
    {
        // On désactive le bouclier
        shield.SetActive(false);

        return State.SUCCESS;
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

        // Si l'agent est toujours a porté
        if (distance < minDistToPunch)
        {
            // On lance l'animation d'attaque
            tokenGrab.PlayOneShot(m_tokenGrabClip);
            animator.SetTrigger("PunchTrigger");
            // On baisse les hp de l'adversaire
            agent.hp -= 10;
            return State.SUCCESS;
        }

        return State.FAILURE;
    }

    /// <summary>
    /// Action par défaut, l'agent attend
    /// </summary>
    public State Idle()
    {
        // on lance l'animation Idle 
        animator.Play("Idle");
        return State.SUCCESS;
    }

    /// <summary>
    /// Action de déplacement
    /// </summary>
    public State GoForward()
    {
        // On lance l'animation de marche 
        animator.SetBool("Walk Forward", true);
        
        // Petit trik pour s'assurer que l'agent reste sur l'axe X
        Transform transform = gameObject.GetComponent<Transform>();
        transform.position = new Vector3(transform.position.x, 0, 0);
        
        return State.SUCCESS;
    }
}