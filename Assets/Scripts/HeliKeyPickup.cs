using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HeliKeyPickup : MonoBehaviour
{
    public UnityEvent OnKeyTouch;

    private void OnTriggerEnter(Collider other)
    {
        OnKeyTouch.Invoke();
        
        Destroy(this.gameObject);
    }

    public void CollectID()
    {
        GameObject.Find("MyManager").GetComponent<MyManager>().HasHeliKey = true;
    }
}