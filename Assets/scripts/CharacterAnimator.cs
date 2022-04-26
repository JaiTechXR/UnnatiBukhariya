using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimator : MonoBehaviour
{   
    Animator animator;
    NavMeshAgent agent;
    const float anismooth = 0.02f;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        float speedper = agent.velocity.magnitude/agent.speed;
        animator.SetFloat("speedper", speedper, anismooth, Time.deltaTime);

    }
}
