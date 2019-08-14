using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton_Player : MonoBehaviour
{
    public static Singleton_Player Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}
