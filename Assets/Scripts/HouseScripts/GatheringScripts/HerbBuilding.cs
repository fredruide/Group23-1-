using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class HerbBuilding : GatherScript
{
    //Skrevet af Jonas C. og Jakob Vestergaard
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            toCarryOver = newScore;
            newScore = 0;
            currentScore = 0;
            Debug.Log(toCarryOver);
            if (null != GameObject.Find("Material_Counter"))
            {
                objMaterial_Counter = GameObject.Find("Material_Counter");
                scrMaterial_Counter = objMaterial_Counter.GetComponent<Material_Counter>();
                scrMaterial_Counter.CheckForHerb(toCarryOver);
            }            
        }
    }



    /*
    //Skrevet af Jakob Vestergaard
    //Gemt til hvis der kommer behøv for at gemme i en .dat fil
    private void SaveScore()
    {
        if (File.Exists(Application.persistentDataPath + "/BuildingInfo1.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/BuildingInfo1.dat", FileMode.Open);
            BuildingInfo buildingInfo = new BuildingInfo();

            buildingInfo.currentHerbHolding = newScore;
            print(buildingInfo.currentHerbHolding);
            bf.Serialize(file, buildingInfo);
            file.Close();
        }
        else
        { 
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/BuildingInfo1.dat");
            BuildingInfo buildingInfo = new BuildingInfo();

            buildingInfo.currentHerbHolding = newScore;
            
            bf.Serialize(file, buildingInfo);
            file.Close();
        }
    }

    private void LoadScore()
    {
        if (File.Exists(Application.persistentDataPath + "/BuildingInfo1.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/BuildingInfo1.dat", FileMode.Open);
            BuildingInfo buildingInfo = (BuildingInfo)bf.Deserialize(file);

            newScore = buildingInfo.currentHerbHolding;
            //print(loadedScore);
            file.Close();
        }
    }
    */
}