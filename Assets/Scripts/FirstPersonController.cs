using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour
{
    //public variables
    public float MoveSpeed = 3;
    public float SprintSpeed = 5; 
    public float RotationSpeed = 180;
    public InputActionAsset CharacterActionAsset;
    public Camera FirstPersonCamera;
    public float Acceleration = .7f;
    public float Deceleration = .9f;
    public float BaseFOV = 60;
    public float SprintFOV = 75;
    //public float MaxJumpHeight = 1;

    //private variables 
    private InputAction moveAction; 
    private InputAction rotateAction;
    private InputAction sprintAction;
    //private InputAction jumpAction;
    private CharacterController characterController;
    private Vector2 moveValue; 
    private Vector2 rotateValue;
    private Vector3 currentRotationAngle;
    private float currentSpeed = 0;
    private float FOV;
    private float verticalMovement = 0; 

    private void OnEnable()
    {
        //enables action map
        CharacterActionAsset.FindActionMap("Gameplay").Enable(); 
    }

    private void OnDisable()
    {
        //disables action map 
        CharacterActionAsset.FindActionMap("Gameplay").Disable();
    }
    
    void Awake()
    {
        //finds controller on game start
        characterController = GetComponent<CharacterController>();

        //sets FOV
        FOV = FirstPersonCamera.fieldOfView; 

        //setting different action variables and correlating them to action map
        moveAction = CharacterActionAsset.FindActionMap("Gameplay").FindAction("Move");
        rotateAction = CharacterActionAsset.FindActionMap("Gameplay").FindAction("Rotate");
        sprintAction = CharacterActionAsset.FindActionMap("Gameplay").FindAction("Sprint");
        //jumpAction = CharacterActionAsset.FindActionMap("Gameplay").FindAction("Jump");

        //disables cursor visability
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; 
    }

    void Update()
    {
        //split everything into functions to make it more legible
        ProcessFPSCam();
        ProcessMovement();
        ProcessJump(); 
    }

    //function for camera setup
    private void ProcessFPSCam()
    {
        //setting rotation
        rotateValue = rotateAction.ReadValue<Vector2>() * RotationSpeed * Time.deltaTime;

        //camera/player rotation
        currentRotationAngle = new Vector3(currentRotationAngle.x - rotateValue.y, currentRotationAngle.y + rotateValue.x, 0);
        FirstPersonCamera.transform.rotation = Quaternion.Euler(currentRotationAngle);
        currentRotationAngle = new Vector3(Mathf.Clamp(currentRotationAngle.x, -85, 85), currentRotationAngle.y, currentRotationAngle.z);
    }

    //all code for movement
    private void ProcessMovement()
    {
        //MoveSpeed vs. SprintSpeed
        if (sprintAction.IsPressed())
        {
            Accelerate(SprintSpeed, SprintFOV);
            moveValue = moveAction.ReadValue<Vector2>() * currentSpeed * Time.deltaTime;
        }
        else
        {
            Accelerate(MoveSpeed, FOV);
            moveValue = moveAction.ReadValue<Vector2>() * currentSpeed * Time.deltaTime;
        }

        //calculate movement direction based on camera's forward
        Vector3 moveDirection = FirstPersonCamera.transform.forward * moveValue.y + FirstPersonCamera.transform.right * moveValue.x;

        moveDirection.y = 0; //ensures no vertical movement
        moveDirection.y += verticalMovement; 
        characterController.Move(moveDirection);
    }

    //function for smoother speed transitions
    void Accelerate(float maxSpeed, float fov)
    {
        //decellerates and accelerates player smoothly by adjusting the player speed over a period of time
        if (currentSpeed >= maxSpeed)
        {
            currentSpeed -= maxSpeed * Deceleration * Time.deltaTime;
        }
        else
        {
            currentSpeed += maxSpeed * Acceleration * Time.deltaTime;
        }

        //increases and decreases the players FOV smoothly depending on move speed over a period of time 
        if (FirstPersonCamera.fieldOfView >= fov)
        {
            FirstPersonCamera.fieldOfView -= fov * Deceleration * Time.deltaTime;
        }
        else
        {
            FirstPersonCamera.fieldOfView += fov * Acceleration * Time.deltaTime;
        }

        FirstPersonCamera.fieldOfView = Mathf.Clamp(FirstPersonCamera.fieldOfView, BaseFOV, SprintFOV);

        /*float CurrentAccelerationTimer = 0;
        CurrentAccelerationTimer += (isSprinting)? Time.deltaTime : -Time.deltaTime;
        CurrentAccelerationTimer = Mathf.Clamp01(CurrentAccelerationTimer);

        FirstPersonCamera.fieldOfView = Mathf.Lerp(BaseFOV, SprintFOV, CurrentAccelerationTimer * AccelerationTime);*/
    }

    //function for all jumping code 
    private void ProcessJump()
    {
        //applying gravity 
        verticalMovement = 0;
        verticalMovement += Physics.gravity.y * Time.deltaTime;
    }

    //draws somes spherical miracles
    private void OnDrawGizmos()
    {
        Gizmos.color = new Vector4 (0, 1, 1, 0.5f);
        Gizmos.DrawSphere(transform.position, 0.5f); 
    }
}
