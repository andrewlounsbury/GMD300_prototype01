using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveAndFreeze : MonoBehaviour
{
    public float moveSpeed = 2.0f; 
    public float freezePositionY = 5.0f;
    public GameObject WasherPlatform; 
    private bool shouldMove = false;
    private bool playerInsideCollider = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInsideCollider = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInsideCollider = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && WasherPlatform != null)
        {
            shouldMove = true; 
        }

        if (shouldMove)
        {
            Vector3 newPosition = WasherPlatform.transform.position + Vector3.up * moveSpeed * Time.deltaTime;
            WasherPlatform.transform.position = newPosition;

            if (WasherPlatform.transform.position.y >= freezePositionY)
            {
                shouldMove = false;
                WasherPlatform.transform.position = new Vector3(WasherPlatform.transform.position.x, freezePositionY, WasherPlatform.transform.position.z);
            }
        }
    }
}