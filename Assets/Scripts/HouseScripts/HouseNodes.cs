using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseNodes : MonoBehaviour
{
    [SerializeField]
    private GameObject herbalist;
    public float gridHerbalistX = 5f;
    public float gridHerbalistY = 5f;
    [SerializeField]
    private GameObject stone;
    public float gridStoneX = 10f;
    public float gridStoneY = 10f;
    [SerializeField]
    private GameObject iron;
    public float gridIronX = 20f;
    public float gridIronY = 20f;

    private bool Building = false;

    // Update is called once per frame
    void Update()
    {
        if (Building)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {                
                Vector3 pos = new Vector3(gridHerbalistX, gridHerbalistY);
                Instantiate(herbalist, pos, Quaternion.identity);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Vector3 pos = new Vector3(gridStoneX, gridStoneY);
                Instantiate(stone, pos, Quaternion.identity);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Vector3 pos = new Vector3(gridIronX, gridIronY);
                Instantiate(iron, pos, Quaternion.identity);
            }
        }   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Det triggerede mig");
            Building = true;
        }
              
            //if (Input.GetKeyDown(KeyCode.Alpha1))
            //{
            //    Debug.Log("Det triggerede mig");
            //    Vector3 pos = new Vector3(gridHerbalistX, gridHerbalistY);
            //    Instantiate(herbalist, pos, Quaternion.identity);
            //}
            //if (Input.GetKeyDown(KeyCode.Alpha2))
            //{
            //    Vector3 pos = new Vector3(gridStoneX, gridStoneY);
            //    Instantiate(stone, pos, Quaternion.identity);
            //}
            //if (Input.GetKeyDown(KeyCode.Alpha3))
            //{
            //    Vector3 pos = new Vector3(gridIronX, gridIronY);
            //    Instantiate(iron, pos, Quaternion.identity);
            //}
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Building = false;
        Debug.Log(Building);
    }

}
