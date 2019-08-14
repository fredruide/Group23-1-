using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm_DamageTaken : MonoBehaviour
{
    private Worm_Controller Worm_Controller_scr;

    private void Start()
    {
        Worm_Controller_scr = GameObject.Find("Worm_Controller").GetComponent<Worm_Controller>();
    }

    public void TakeDmg(int dmg)
    {       
        Worm_Controller_scr.hp -= dmg;
    }
}
