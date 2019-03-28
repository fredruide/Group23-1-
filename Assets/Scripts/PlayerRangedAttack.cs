using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRangedAttack : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            Fire();
        }
    }

    void Fire()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
}
