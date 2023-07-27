using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollideInteract : MonoBehaviour
{
    public bool stopMovement;
    PlayerMovement playerMovement;
    public float intervalPerEvent;
    public UnityEvent[] events;

    bool hasEntered = false;

    private void Start()
    {
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!hasEntered)
            {
                hasEntered = true;

                if (stopMovement)
                    playerMovement.ToggleControl(false);

                events[0].Invoke();

                if (events.Length > 1)
                    StartCoroutine(DoEvents());
                else
                { 
                    Destroy(gameObject);
                }
            }
        }
    }

    IEnumerator DoEvents()
    {
        while (true)
        {
            for (int i = 1; i < events.Length; i++)
            {
                yield return new WaitForSeconds(intervalPerEvent);

                events[i].Invoke();
            }

            if (stopMovement)
                playerMovement.ToggleControl(true);

            Destroy(gameObject);
        }
    }
}
