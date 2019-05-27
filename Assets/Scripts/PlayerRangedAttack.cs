using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRangedAttack : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;
    Rigidbody2D rb;
    PlayerScript ps;
    public int ammo;
    public float reloadTime;
    public float startReloadTime;
    public static bool isNotReloading;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        ps = GetComponent<PlayerScript>();
    }

    void Update()
    {
        if (reloadTime <= 0)
        {
            if ((Input.GetButtonDown("Fire2") && ammo > 0) && reloadTime < 0)
            {
                Fire();
                ammo--;
            }
            else if (Input.GetButtonDown("Fire2") && ammo == 0 && ps._isGrounded)
            {
                reload();
            }
        }
        else
        {
            reloadTime -= Time.deltaTime;
        }
        if (reloadTime <=0+ 0)
        {
            isNotReloading = true;
        }       
    }

    void Fire()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        FindObjectOfType<AudioManager>().Play("Shoot");
    }

    void reload()
    {
        reloadTime = startReloadTime;
        ammo = 1;
        isNotReloading = false;
        rb.velocity = new Vector2(0, rb.velocity.y);
        FindObjectOfType<AudioManager>().Play("Reload");
        Debug.Log("Reloading");
    }
}