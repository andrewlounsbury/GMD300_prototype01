using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class RaycastInteract : MonoBehaviour
{
    public float Distance = 1; 
    public Camera PlayerCamera;


    public InputActionAsset CharacterActionAsset;
    private InputAction InteractAction;

    private void Awake()
    {
        CharacterActionAsset.FindActionMap("Gameplay").Enable(); 

        InteractAction = CharacterActionAsset.FindActionMap("Gameplay").FindAction("Interact");
    }

    private void OnDisable()
    {
        CharacterActionAsset.FindActionMap("Gameplay").Disable();
    }

    void Update()
    {
        Ray interactionRay = new Ray(PlayerCamera.transform.position, PlayerCamera.transform.forward);
        RaycastHit interactionHitInfo;

        bool interactinputPressed = InteractAction.ReadValue<float>() > 0;

        bool showInteractPrompt = false;

        if (Physics.Raycast(interactionRay, out interactionHitInfo, 1)) 
        {
            if (interactionHitInfo.transform.tag == "Interactable") 
            {

                showInteractPrompt = true; 

                if (interactinputPressed)
                {
                    interactionHitInfo.transform.SendMessage("OnPlayerInteract", SendMessageOptions.DontRequireReceiver);
                }
            }
        }
        UIAnimationManager.Instance.ShowInteractPrompt(showInteractPrompt);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawRay(PlayerCamera.transform.position, PlayerCamera.transform.forward);
    }
}
