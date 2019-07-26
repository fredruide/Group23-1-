using UnityEngine;
using UnityEngine.UI;

public class PlayerRangedAttack : MonoBehaviour
{
    public Transform firePoint;
    public GameObject arrow;
    Rigidbody2D rb;
    PlayerScript ps;
    public float drawTime;
    public float startDrawTime;
    public static bool isNotDrawing;
    public static bool buttonHeld;
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
        if (Input.GetButtonDown("Fire2") && ps._isGrounded && drawTime <= 0)
        {
            Draw();
        }
        else
        {
            drawTime -= Time.deltaTime;
        }
        if (Input.GetButton("Fire2") == true)
        {
            buttonHeld = true;
        }
        else
        {
            buttonHeld = false;
        }
        if (drawTime <= 0 && buttonHeld == false)
        {
            isNotDrawing = true;
        }
        print("Held " + buttonHeld + " Drawing " + isNotDrawing);

    }
    void Fire()
    {
        Instantiate(arrow, firePoint.position, firePoint.rotation);
        scrMC.CheckForAmmo(-1);
        //FindObjectOfType<AudioManager>().Play("Shoot");
    }

    void Draw()
    {
        drawTime = startDrawTime;
        isNotDrawing = false;
        rb.velocity = new Vector2(0, rb.velocity.y);
        //FindObjectOfType<AudioManager>().Play("Draw");
    }






    //    if (drawTime <= 0)
    //        {
    //            if (Input.GetButtonDown("Fire2") && drawTime< 0)
    //            {                
    //                Fire();

    //}           
    //            else if (Input.GetButtonDown("Fire2") && ps._isGrounded && scrMC.AmmoUsed() >= 1)
    //            {
    //                reload();
    //scrMC.CheckForAmmo(-1);
    //            }
    //        }
    //        else
    //        {
    //            drawTime -= Time.deltaTime;
    //        }
    //        if (drawTime <= 0 + 0)
    //        {
    //            isNotDrawing = true;
    //        }       
}