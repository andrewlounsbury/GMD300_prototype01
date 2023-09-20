using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))] 

public class UIAnimationManager : MonoBehaviour
{
    public static UIAnimationManager Instance;
    private Animator animator;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this) 
        {
            Destroy(this); 
        
        }

        animator = GetComponent<Animator>();

    }


    private void OnDisable()
    {
        if (Instance == this)
        {
            Instance = null; 
        }
    }


    public void ShowInteractPrompt(bool showPrompt)
    {
        animator.SetBool("showInteractionPrompt", showPrompt); 
    }
}
