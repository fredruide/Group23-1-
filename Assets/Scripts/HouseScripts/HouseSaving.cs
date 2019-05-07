using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Xml.Serialization;
using System.IO;

public class HouseSaving : MonoBehaviour
{
    BuildingInfo buildingInfo = new BuildingInfo();
    public GameObject objHouseNode;
    private HouseNodes scrHouseNodes;
    GameObject objHerbBuilding = GameObject.Find("ResourceHerb");
    GameObject objIronBuilding = GameObject.Find("ResourceIron");
    GameObject objStoneBuilding = GameObject.Find("ResourceStone");        
    
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
    
    private void xmlSave()
    {
        scrHouseNodes = objHouseNode.GetComponent<HouseNodes>();
        ResourceBuildingCheck();


        XmlSerializer serializer = new XmlSerializer(typeof(BuildingInfo));
        StreamWriter writer = new StreamWriter(Application.persistentDataPath + "/save.xml");
        serializer.Serialize(writer.BaseStream, buildingInfo);
        writer.Close();
    }
    
    private void ResourceBuildingCheck()
    {        
        if (null == GameObject.Find("ResourceHerb"))
        {
            buildingInfo.herbBuilt = false;
            buildingInfo.currentHerbHolding = 0;
        }
        else
        {
            HerbBuilding scrHerbBuilding = objHerbBuilding.GetComponent<HerbBuilding>();
            buildingInfo.herbBuilt = scrHouseNodes.herbBuilt;
            buildingInfo.currentHerbHolding = scrHerbBuilding.newScore;
        }
        if (null == GameObject.Find("ResourceIron"))
        {
            buildingInfo.ironBuilt = false;
            buildingInfo.currentIronHolding = 0;
        }
        else
        {
            IronBuilding scrIronBuilding = objIronBuilding.GetComponent<IronBuilding>();
            buildingInfo.ironBuilt = scrHouseNodes.ironBuilt;
            buildingInfo.currentIronHolding = scrIronBuilding.newScore;
        }

        if (null == GameObject.Find("ResourceStone"))
        {
            buildingInfo.stoneBuilt = false;
            buildingInfo.currentStoneHolding = 0;
        }
        else
        {
            HerbBuilding scrHerbBuilding = objHerbBuilding.GetComponent<HerbBuilding>();
            buildingInfo.stoneBuilt = scrHouseNodes.stoneBuilt;
            buildingInfo.currentStoneHolding = scrHerbBuilding.newScore;
        }       
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



