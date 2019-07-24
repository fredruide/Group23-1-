using UnityEngine;
using UnityEngine.UI;

public class PlayerRangedAttack : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;
    Rigidbody2D rb;
    PlayerScript ps;
    private int ammoMagazine;
    public float reloadTime;
    public float startReloadTime;
    public static bool isNotReloading;
    //J.C. {
    public GameObject MCAmmo_Counter;
    public Material_Counter scrMC;

    public GameObject objAmmo_CounterText;
    public Text Ammo_CounterText;
    //      }

    // Frederik{
    Animator ani;
        //}
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        ps = GetComponent<PlayerScript>();
        ani = GetComponent<Animator>();
    }

    private void Awake()
    {//J.C.
        MCAmmo_Counter = GameObject.Find("Material_Counter");
        scrMC = MCAmmo_Counter.GetComponent<Material_Counter>();
        //Update value on the UI
        scrMC.PrintToUI2();
        scrMC.AmmoUsed();
    }

    void Update()
    {
        //Debug.Log("reloadTime: " + reloadTime);
        if (reloadTime <= 0)
        {
            //Debug.Log("input Fire2: " + Input.GetButtonDown("Fire2") + " ammoMagazine: " + ammoMagazine + " reloadTime: " + reloadTime);
            //Debug.Log("input Fire2: " + Input.GetButtonDown("Fire2") + " ammoMagazine: " + ammoMagazine + " ps.isGrounded: " + ps._isGrounded + " scrMC.AmmoUsed(): " + scrMC.AmmoUsed());
            if ((Input.GetButtonDown("Fire2") && ammoMagazine > 0) && reloadTime < 0)
            {
                ani.SetBool("IsRangedAttack", true);
                //Fire();
                ammoMagazine--;
                
            }
            //else if (Input.GetButtonDown("Fire2") && ammo == 0 && ps._isGrounded)            
            else if (Input.GetButtonDown("Fire2") && ammoMagazine == 0 && ps._isGrounded && scrMC.AmmoUsed() >= 1)
            {
                reload();
                scrMC.CheckForAmmo(-1);
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

    public void Fire()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        //FindObjectOfType<AudioManager>().Play("Shoot");
    }

    void reload()
    {
        reloadTime = startReloadTime;
        ammoMagazine = 1;
        isNotReloading = false;
        rb.velocity = new Vector2(0, rb.velocity.y);
        //FindObjectOfType<AudioManager>().Play("Reload");       
    }
}