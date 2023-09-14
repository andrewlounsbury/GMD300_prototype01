using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IDPickup : MonoBehaviour
{
    public UnityEvent OnIDTouch;

    private void OnTriggerEnter(Collider other)
    {
        OnIDTouch.Invoke();
        
        Destroy(this.gameObject);
    }

    public void CollectID()
    {
        GameObject.Find("MyManager").GetComponent<MyManager>().HasID = true;
    }
}