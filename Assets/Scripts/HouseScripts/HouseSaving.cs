using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class HouseSaving : MonoBehaviour
{
    private bool herbBuilt;
    private int currentScore;

    public void SaveHouses()
    {
        
        if (File.Exists(Application.persistentDataPath + "/BuildingInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/BuildingInfo.dat", FileMode.Open);
            BuildingInfo buildingInfo = new BuildingInfo();

            buildingInfo.herbBuilt = herbBuilt;
            buildingInfo.currentHerbHolding = currentScore;

            bf.Serialize(file, buildingInfo);
            file.Close();
        }
        else
        {
            FileStream file = File.Create(Application.persistentDataPath + "/BuildingInfo.dat");
        }
        //FileStream file = File.Create(Application.persistentDataPath + "/BuildingInfo.dat");
        //BuildingInfo buildingInfo = new BuildingInfo();

        //buildingInfo.herbBuilt = herbBuilt;
        //buildingInfo.currentHerbHolding = currentScore;
        //print(buildingInfo.herbBuilt + " " + currentScore);
        //print(buildingInfo.herbBuilt + " " + buildingInfo.currentHerbHolding);
    }

    public void LoadHouses()
    {
        if (File.Exists(Application.persistentDataPath + "/BuildingInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/BuildingInfo.dat", FileMode.Open);
            BuildingInfo buildingInfo = (BuildingInfo)bf.Deserialize(file);

            herbBuilt = buildingInfo.herbBuilt;
            currentScore = buildingInfo.currentHerbHolding;
            //print(buildingInfo.herbBuilt + " " + currentScore);
            //print(buildingInfo.herbBuilt + " " + buildingInfo.currentHerbHolding);
            
            file.Close();
        }
    }

}

[Serializable]
class BuildingInfo
{
    public bool herbBuilt { get; set; }
    public int currentHerbHolding { get; set; }
    public bool stoneBuilt { get; set; }
    public int currentStoneHolding { get; set; }
    public bool ironBuilt { get; set; }
    public int currentIronHolding { get; set; }
}

