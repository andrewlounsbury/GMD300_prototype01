using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorSwitchEvent : MonoBehaviour
{
    public UnityEvent OnSwitchTouch;
    public bool OnSwitch = true;

    private void OnTriggerEnter(Collider other)
    {
        if(OnSwitch)
        {
            OnSwitchTouch.Invoke();
        }
    }

    private void Update ()
    {
        OnSwitch = GameObject.Find("MyManager").GetComponent<MyManager>().HasID; 
    }
}
