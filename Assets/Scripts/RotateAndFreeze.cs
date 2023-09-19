using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAndFreeze : MonoBehaviour
{
    public float RotationSpeed = 2.0f;
    public float MoveSpeed = 2.0f;
    public float FreezeRotationY = 90.0f;
    public float FreezePositionY = 0.0f;
    public GameObject Crane;
    public GameObject CraneRope;
    private bool shouldRotate = false;
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
        if (Input.GetKeyDown(KeyCode.E) && Crane != null && playerInsideCollider)
        {
            shouldRotate = true;
        }

        if (shouldRotate)
        {
            // Rotate crane
            Vector3 newRotation = new Vector3(0, RotationSpeed * Time.deltaTime, 0);
            Crane.transform.eulerAngles += newRotation;

            // Move platform
            Vector3 newPosition = new Vector3(0, MoveSpeed * Time.deltaTime, 0);
            CraneRope.transform.position += newPosition;

            if (Crane.transform.eulerAngles.y >= FreezeRotationY -1 && Crane.transform.eulerAngles.y <= FreezeRotationY)
            {
                shouldRotate = false;
                Crane.transform.eulerAngles = new Vector3(Crane.transform.eulerAngles.x, FreezeRotationY, Crane.transform.eulerAngles.z);
            }
        }
    }





}
