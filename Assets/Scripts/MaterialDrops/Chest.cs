using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

//Skrevet af Jonas C.
public class Chest : MonoBehaviour
{
    public GameObject Chest_Location;
    public GameObject Herb_Drop;
    public GameObject Stone_Drop;
    public GameObject Metal_Drop;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (collision.gameObject.tag== "Player")
        {
            int iH = UnityEngine.Random.Range(0, 10);
            while (iH > 0)
            {
                Instantiate(Herb_Drop, Chest_Location.transform.position, Quaternion.identity);
                iH--;
                //Insert some wait function
            }*/

            //Spawner mellem 0 og 10 herbs
            for (int i = 0; i < UnityEngine.Random.Range(0, 10); i++)
            {
                Instantiate(Herb_Drop, Chest_Location.transform.position, Quaternion.identity);
            //Insert some wait function?
        }

        //Spawner mellem 0 og 10 stone
        for (int i = 0; i < UnityEngine.Random.Range(0, 10); i++)
            {
                Instantiate(Stone_Drop, Chest_Location.transform.position, Quaternion.identity);
            }

            //Spawner mellem 0 og 10 metal
            for (int i = 0; i < UnityEngine.Random.Range(0, 10); i++)
            {
                Instantiate(Metal_Drop, Chest_Location.transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
