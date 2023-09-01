using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour
{
    public float MoveSpeed = 3;
    public float RotationSpeed = 2500;
    public InputActionAsset CharacterActionAsset;
    public Camera FirstPersonCamera;
    public Transform PlayerBody; 

    private InputAction moveAction; 
    private InputAction rotateAction;

    private CharacterController characterController;

    private Vector2 moveValue; 
    private Vector2 rotateValue;
    private Vector3 currentRotationAngle;

    private void OnEnable()
    {
        CharacterActionAsset.FindActionMap("Gameplay").Enable(); 
    }

    private void OnDisable()
    {
        CharacterActionAsset.FindActionMap("Gameplay").Disable();
    }
    
    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        moveAction = CharacterActionAsset.FindActionMap("Gameplay").FindAction("Move");
        rotateAction = CharacterActionAsset.FindActionMap("Gameplay").FindAction("Rotate");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; 
    }

    void Update()
    {
        //setting variables
        moveValue = moveAction.ReadValue<Vector2>() * MoveSpeed * Time.deltaTime;
        rotateValue = rotateAction.ReadValue<Vector2>() * RotationSpeed * Time.deltaTime;

       //camera/player rotation
        currentRotationAngle = new Vector3(currentRotationAngle.x - rotateValue.y, currentRotationAngle.y + rotateValue.x, 0);
        FirstPersonCamera.transform.rotation = Quaternion.Euler(currentRotationAngle);
        currentRotationAngle = new Vector3(Mathf.Clamp(currentRotationAngle.x, -85, 85), currentRotationAngle.y, currentRotationAngle.z);
        PlayerBody.Rotate(Vector3.up * rotateValue.x);

        //movement stuff
        characterController.Move(new Vector3(moveValue.x, 0, moveValue.y));
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = new Vector4 (0, 1, 1, 0.5f);
        Gizmos.DrawSphere(transform.position, 0.5f); 
    }
}
