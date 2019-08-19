using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton_UI : MonoBehaviour
{
    public static Singleton_UI Instance;

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
