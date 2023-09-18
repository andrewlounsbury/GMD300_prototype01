using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoneyPickup : MonoBehaviour
{
    public UnityEvent OnMoneyTouch;
    
    private void OnTriggerEnter(Collider other)
    {
        OnMoneyTouch.Invoke();
        //waypoint.ActivateWaypoint(); 
        Destroy(this.gameObject);
    }

    public void CollectMoney()
    {
        GameObject.Find("MyManager").GetComponent<MyManager>().HasMoney = true;
    }
}
