using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LiftButton : MonoBehaviour
{
    private bool playerInsideCollider = false;

    public UnityEvent OnLiftButtonEnter;
    public UnityEvent OnLiftButtoneExit;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInsideCollider = true;
            OnLiftButtonEnter.Invoke();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInsideCollider = false;
            OnLiftButtoneExit.Invoke();
        }
    }
}
