using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveAndFreezeCraneRope : MonoBehaviour
{
    public float MoveSpeed = 2.0f; 
    public float FreezePositionY = 5.0f;
    public GameObject CraneRope; 
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
        if (Input.GetKeyDown(KeyCode.E) && CraneRope != null)
        {
            shouldMove = true; 
        }

        if (shouldMove)
        {
            Vector3 newPosition =   CraneRope.transform.position + Vector3.up * MoveSpeed * Time.deltaTime;
            CraneRope.transform.position = newPosition;

            if (CraneRope.transform.position.y >= FreezePositionY)
            {
                shouldMove = false;
                CraneRope.transform.position = new Vector3(CraneRope.transform.position.x, FreezePositionY, CraneRope.transform.position.z);
            }
        }
    }
}