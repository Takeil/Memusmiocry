using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAnimation : MonoBehaviour
{
    public float seconds = 1f;
    public Animator animator;
    void Start()
    {
        animator.speed = 0;

        if (seconds< 0)
            StartCoroutine(AnimationDelay(Random.Range(1,30)));
        else
            StartCoroutine(AnimationDelay(seconds));
    }

    IEnumerator AnimationDelay(float time)
    {
        yield return new WaitForSeconds(time);
        animator.speed = 1;
    }
}
