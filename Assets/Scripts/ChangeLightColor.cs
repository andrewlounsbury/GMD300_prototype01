using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLightColor : MonoBehaviour
{
    public Color ReColor; 

    public void ChangeColor()
    {
        GetComponent<Light>().color = ReColor; 
    }
}
