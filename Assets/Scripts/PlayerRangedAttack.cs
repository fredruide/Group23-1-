using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRangedAttack : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;
    public int ammo;
    public float reloadTime;
    public float startReloadTime;
    void Update()
    {
        if (reloadTime <= 0)
        {
            if ((Input.GetButtonDown("Fire2") && ammo > 0) && reloadTime < 0)
            {
                Fire();
                ammo--;
            }
            else if (Input.GetButtonDown("Fire2") && ammo == 0)
            {
                reload();
            }
        }
        else
        {
            reloadTime -= Time.deltaTime;
        }
        if (reloadTime <= 0)
        {
            PlayerScript.canMoveHori = true;
        }

    }

    void Fire()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }

    void reload()
    {
        reloadTime = startReloadTime;
        ammo = 1;
        PlayerScript.canMoveHori = false;
        Debug.Log("Reloading");
    }
}