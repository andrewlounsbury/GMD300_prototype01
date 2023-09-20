using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 

public class PushButtonInteraction : MonoBehaviour
{
    public UnityEvent OnButtonPress;

    public void OnPlayerInteract()
    {
        Debug.Log("HIT");
        OnButtonPress.Invoke(); 
    }
}
