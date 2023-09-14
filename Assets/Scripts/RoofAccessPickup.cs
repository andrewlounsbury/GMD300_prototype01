using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RoofAccessPickup : MonoBehaviour
{
    public UnityEvent OnDoorKeyTouch;

    private void OnTriggerEnter(Collider other)
    {
        OnDoorKeyTouch.Invoke();

        Destroy(this.gameObject);
    }

    public void CollectRoofKey()
    {
        GameObject.Find("MyManager").GetComponent<MyManager>().HasDoorKey = true;
    }
}