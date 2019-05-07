using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Xml.Serialization;
using System.IO;

public class HouseSaving : MonoBehaviour
{
    public GameObject objHouseSaving;
    public GameObject objHerbBuilding;
    //private HerbBuilding scrHerbBuilding;
    private HouseNodes scrHouseNodes;

    private void Start()
    {
        //herbBuilding = GameObject.FindObjectOfType<HerbBuilding>();
        xmlLoad();
               
        /*
        int peter;
        BuildingInfo buildingInfo = new BuildingInfo();
        peter = buildingInfo.funtion();
        print(peter);
        */
    }
    
    //private void test()
    //{
    //    int x;
    //    bool y;
    //    x = scrHerbBuilding.newScore;
    //    y = scrHouseNodes.herbBuilt;
    //    print(x + " " + y);
    //}
   
    private void xmlSave()
    {
        scrHouseNodes = objHouseSaving.GetComponent<HouseNodes>();
        GameObject g = GameObject.Find("ResourceHerb");
        HerbBuilding scrHerbBuilding = g.GetComponent<HerbBuilding>();         

        BuildingInfo buildingInfo = new BuildingInfo();
        buildingInfo.herbBuilt = scrHouseNodes.herbBuilt;
        buildingInfo.currentHerbHolding = scrHerbBuilding.newScore;

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



