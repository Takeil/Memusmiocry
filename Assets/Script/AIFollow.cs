using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFollow : MonoBehaviour
{
    public bool followTarget = false;

    public float speed;
    float movement = 0;

    public CharacterController2D controller;
    public Animator animator;
    public Transform target;

    public float MaxDistance = 5;
    public float MinDistance = 1;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (followTarget)
        {
            if (MaxDistance < Vector2.Distance(target.position, transform.position))
            {
                if (target.position.x > transform.position.x)
                    movement = 1 * speed;

                if (target.position.x < transform.position.x)
                    movement = -1 * speed;
            }

            if (MinDistance > Vector2.Distance(target.position, transform.position))
            {
                movement = 0;
            }

            animator.SetFloat("Speed", movement);
        }
    }

    void FixedUpdate()
    {
        controller.Move(movement * Time.fixedDeltaTime, false, false);
    }
    public void ToggleFollow()
    {
        followTarget = !followTarget;
    }
}
