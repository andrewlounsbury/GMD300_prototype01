using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyManager : MonoBehaviour
{
    public static MyManager Instance;

    public int PlayerScore = 0;
    public bool HasID = false;
    public bool HasHeliKey = false;
    public bool HasCraneKey = false;
    public bool HasMoney = false;
    public bool HasDoorKey = false; 

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; 
            DontDestroyOnLoad(this.gameObject);
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnDisable()
    {
        if (Instance = this)
        {
            Instance = null;
        }
    }

    public void AddScore (int scoreToAdd)
    {
        PlayerScore += scoreToAdd;
    }
}
