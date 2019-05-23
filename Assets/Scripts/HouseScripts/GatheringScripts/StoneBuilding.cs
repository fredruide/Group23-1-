using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class StoneBuilding : GatherScript
{
    //Skrevet af Jonas C.

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
                scrMaterial_Counter.CheckForStone(toCarryOver);
            }
        }
    }

    /*
    //Skrevet af Jakob Vestergaard
    
    //Gemt til hvis der kommer behøv for at gemme i en .dat fil
    private void saveScore()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/BuildingInfo.dat");

        BuildingInfo buildingInfo = new BuildingInfo();
        // Virker ikke fordi at currentscore ikke er en ting længere
        //buildingInfo.currentStoneHolding = int.Parse(currentScore);
        bf.Serialize(file, buildingInfo);
    }

    private void loadScore()
    {
        if (File.Exists(Application.persistentDataPath + "/BuildingInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/BuildingInfo.dat", FileMode.Open);
            BuildingInfo buildingInfo = (BuildingInfo)bf.Deserialize(file);
            // Virker ikke fordi at currentscore ikke er en ting længere
            //currentScore = buildingInfo.currentIronHolding.ToString();
            file.Close();
        }
        
    }
    */
}

