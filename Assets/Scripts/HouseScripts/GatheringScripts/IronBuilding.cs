using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class IronBuilding : GatherScript
{
    /*
    //Skrevet af Jakob Vestergaard
    //Gemt til hvis der kommer behøv for at gemme i en .dat fil
    private void saveScore()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/BuildingInfo.dat");

        BuildingInfo buildingInfo = new BuildingInfo();
        // Virker ikke fordi at currentscore ikke er en ting længere
        //buildingInfo.currentIronHolding = int.Parse(currentScore);
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
        }
    }
    */
}