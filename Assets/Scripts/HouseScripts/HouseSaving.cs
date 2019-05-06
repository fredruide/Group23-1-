using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Xml.Serialization;
using System.IO;

public class HouseSaving : MonoBehaviour
{
    private HerbBuilding herbBuilding;
    private HouseNodes houseNodes;

    private void Start()
    {
        //herbBuilding = GameObject.FindObjectOfType<HerbBuilding>();
        
               
        /*
        int peter;
        BuildingInfo buildingInfo = new BuildingInfo();
        peter = buildingInfo.funtion();
        print(peter);
        */
    }
    
    private void test()
    {
        int x;
        bool y;
        x = herbBuilding.newScore;
        y = houseNodes.herbBuilt;
        print(x + " " + y);
    }
   
    private void xmlSave()
    {
        herbBuilding = GetComponent<HerbBuilding>();
        houseNodes = GetComponent<HouseNodes>();

        BuildingInfo buildingInfo = new BuildingInfo();
        buildingInfo.herbBuilt = houseNodes.herbBuilt;
        buildingInfo.currentHerbHolding = herbBuilding.newScore;

        XmlSerializer serializer = new XmlSerializer(typeof(BuildingInfo));
        StreamWriter writer = new StreamWriter(Application.persistentDataPath + "/save.xml");
        serializer.Serialize(writer.BaseStream, buildingInfo);
        writer.Close();
    }

   

    public void xmlLoad()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(BuildingInfo));
        StreamReader reader = new StreamReader(Application.persistentDataPath + "/save.xml");
        BuildingInfo buildingInfo = (BuildingInfo)serializer.Deserialize(reader.BaseStream);

        print(buildingInfo.herbBuilt);
    }

    private void OnApplicationQuit()
    {        
        xmlSave(); 
    }
}

[Serializable]
public class BuildingInfo
{
    public bool herbBuilt { get; set; }
    public int currentHerbHolding { get; set; }
    public bool stoneBuilt { get; set; }
    public int currentStoneHolding { get; set; }
    public bool ironBuilt { get; set; }
    public int currentIronHolding { get; set; }
}



