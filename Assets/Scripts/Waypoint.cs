using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    private FirstPersonController controller;
    private TextMesh waypointText;
    [SerializeField] private int fontSizeTweak = 2;
    [SerializeField] private int minDistance = 5; 
    void Start()
    {
        controller = FindObjectOfType<FirstPersonController>();
        waypointText = GetComponent<TextMesh>();
    }

    void Update()
    {
        int distance = (int) Vector3.Distance(transform.position, controller.transform.position);  
        waypointText.text = distance.ToString() + "m";

        if(distance > minDistance)
        {
            waypointText.fontSize = distance * fontSizeTweak;
        }
    }
}
