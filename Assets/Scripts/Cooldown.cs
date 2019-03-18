using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooldown : MonoBehaviour
{
    public int cooldownTime = 2;

    private float nextFireTime = 0;

    public float tenSec = 10;
    public bool timerRunning = true;
    int i;

    private void Update()
    {




        if (timerRunning)
        {
            tenSec = tenSec - Time.smoothDeltaTime;
            if (tenSec >= 0)
            {
                Debug.Log(i++);
            }
            else
            {
                Debug.Log("Done");
                timerRunning = false;
            }
        }



        if (Time.time > nextFireTime)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                print("Cooldown started");
                nextFireTime = Time.time + cooldownTime;
            }
        }
    }
}
