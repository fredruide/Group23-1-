using UnityEngine;
using UnityEngine.UI;

public class PlayerRangedAttack : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;
    Rigidbody2D rb;
    PlayerScript ps;
    public int ammoMagazine;
    public float reloadTime;
    public float startReloadTime;
    public static bool isNotReloading;
    //J.C. {
    public GameObject MCAmmo_Counter;
    public Material_Counter scrMC;

    public GameObject objAmmo_CounterText;
    public Text Ammo_CounterText;
    //      }
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        ps = GetComponent<PlayerScript>();
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
        if (reloadTime <= 0)
        {
            if ((Input.GetButtonDown("Fire2") && ammoMagazine > 0) && reloadTime < 0)
            {
                Fire();
                ammoMagazine--;
                
            }
            else if (Input.GetButtonDown("Fire2") && ammoMagazine == 0 && ps._grounded && scrMC.AmmoUsed() >= 1)
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

    void Fire()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        FindObjectOfType<AudioManager>().Play("Shoot");
    }

    void reload()
    {
        reloadTime = startReloadTime;
        ammoMagazine = 1;
        isNotReloading = false;
        rb.velocity = new Vector2(0, rb.velocity.y);
        FindObjectOfType<AudioManager>().Play("Reload");
        Debug.Log("Reloading");
    }
}