using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickupSystems : MonoBehaviour
{
    public UnityEvent OnIDTouch;
    public UnityEvent OnIDReadTouch;
    public UnityEvent OnMoneyTouch;
    public UnityEvent OnDoorKeyTouch;
    public UnityEvent OnDoorLockTouch;
    public UnityEvent OnDoorLock1Touch;
    public UnityEvent OnDoorLock2Touch;
    //public UnityEvent OnLiftButtonInteract; 
    public UnityEvent OnCraneKeyTouch;
    public UnityEvent OnCraneButtonTouch;
    public UnityEvent OnHeliKeyTouch;
    public UnityEvent OnHeliTouch;

    public Component IDCollider;
    public Component IDReadCollider;
    public Component MoneyCollider;
    public Component DoorKeyCollider;
    public Component DoorLockCollider;
    public Component DoorLockCollider1;
    public Component DoorLockCollider2;
    //public Component LiftButtonCollider; 
    public Component CraneKeyCollider;
    //public Component CraneButtonCollider;
    public Component HeliKeyCollider;
    public Component HeliCollider;

    public bool OnIDRead = true;
    public bool OnDoorUnlock = true;
    //public bool OnCraneButtonPress = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other == IDCollider)
        {
            OnIDTouch.Invoke();
            CollectID();
        }

        if (other == IDReadCollider && MyManager.Instance.HasID == true)
        {
            OnIDReadTouch.Invoke();
        }

        if (other == MoneyCollider)
        {
            OnMoneyTouch.Invoke();
            CollectMoney();
        }

        if (other == DoorKeyCollider)
        {
            OnDoorKeyTouch.Invoke();
            CollectDoorKey();
        }

        if (other == DoorLockCollider && MyManager.Instance.HasDoorKey == true)
        {
            OnDoorLockTouch.Invoke();

        }

        if (other == DoorLockCollider1 && MyManager.Instance.HasDoorKey == true)
        {
            OnDoorLock1Touch.Invoke();

        }

        if (other == DoorLockCollider2 && MyManager.Instance.HasDoorKey == true)
        {
            OnDoorLock2Touch.Invoke();

        }

       //else if (other == LiftButtonCollider)
       //{
       //    OnLiftButtonInteract.Invoke(); 
       //}

        if (other == CraneKeyCollider)
        {
            OnCraneKeyTouch.Invoke();
            CollectCraneKey();
        }

        if (MyManager.Instance.HasCraneKey == true)
        {
           OnCraneButtonTouch.Invoke();
        }

        if (other == HeliKeyCollider)
        {
            OnHeliKeyTouch.Invoke();
            CollectHeliKey();
        }
    }

    public void CollectID()
    {
        GameObject.Find("MyManager").GetComponent<MyManager>().HasID = true;
    }

    public void CollectMoney()
    {
        GameObject.Find("MyManager").GetComponent<MyManager>().HasMoney = true;
    }

    public void CollectDoorKey()
    {
        GameObject.Find("MyManager").GetComponent<MyManager>().HasDoorKey = true;
    }

    public void CollectCraneKey()
    {
        GameObject.Find("MyManager").GetComponent<MyManager>().HasCraneKey = true;
    }

    public void CollectHeliKey()
    {
        GameObject.Find("MyManager").GetComponent<MyManager>().HasHeliKey = true;
    }

    private void Update()
    {
        OnIDRead = GameObject.Find("MyManager").GetComponent<MyManager>().HasID;
        OnDoorUnlock = GameObject.Find("MyManager").GetComponent<MyManager>().HasDoorKey;
        //OnCraneButtonPress = GameObject.Find("MyManager").GetComponent<MyManager>().HasCraneKey;

    }

}