using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalMover : MonoBehaviour
{
    public static GlobalMover Instance;
    public GameObject player;

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
