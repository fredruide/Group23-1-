using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Xml.Serialization; 
using System.IO;

public class HouseSaving : MonoBehaviour
{
    //Skrevet af Jakob Vestergaard
    /*
    Housesaving er done for nu, indtil at der tillægges flere bygninger
    TODO
    Nu mangler vi et system for at holde resourcer, 
    tage resourcer fra bygninger, 
    bruge resourcer når vi bygger,
    og få nogle tilbage når vi sletter dem
    */
    BuildingInfo buildingInfo = new BuildingInfo();
    public GameObject objHouseNode;
    private HouseNodes scrHouseNodes;
    private GameObject objHerbBuilding;
    private GameObject objIronBuilding;
    private GameObject objStoneBuilding;

    public GameObject UI;
    int x = 0;

    private void Start()
    {                
        xmlLoad();
    }

    /*
    Vi bruger xmlserializer til at omdanne vores information til et format som kan lægges i en XML fil,
    Streamwriter til at skrive og læse dataen
    Vi bruger et field kaldet Buildinginfo og den skal explicit være en [Serializablefield]
    */
    public void xmlSave()
    {
        ResourceBuildingCheck();        
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
        scrHouseNodes = objHouseNode.GetComponent<HouseNodes>();
        scrHouseNodes.herbBuilt = buildingInfo.herbBuilt;
        scrHouseNodes.ironBuilt = buildingInfo.ironBuilt;
        scrHouseNodes.stoneBuilt = buildingInfo.stoneBuilt;

        while (x == 0)
        {            
            scrHouseNodes.BuildingsBuilt();
            x = 1;
        } 

        if (null != GameObject.Find("ResourceHerb"))
        {
            objHerbBuilding = GameObject.Find("ResourceHerb");
            HerbBuilding scrHerbBuilding = objHerbBuilding.GetComponent<HerbBuilding>();
            scrHerbBuilding.newScore = buildingInfo.currentHerbHolding;
        }
        if (null != GameObject.Find("ResourceIron"))
        {
            objIronBuilding = GameObject.Find("ResourceIron");
            IronBuilding scrIronBuilding = objIronBuilding.GetComponent<IronBuilding>();
            scrIronBuilding.newScore = buildingInfo.currentIronHolding;
        }
        if (null != GameObject.Find("ResourceStone"))
        {
            objStoneBuilding = GameObject.Find("ResourceStone");
            StoneBuilding scrStoneBuilding = objStoneBuilding.GetComponent<StoneBuilding>();
            scrStoneBuilding.newScore = buildingInfo.currentStoneHolding;
        }
     
        //(buildingInfo.herbBuilt);
        reader.Close();
    }

    private void ResourceBuildingCheck()
    {
        objHerbBuilding = GameObject.Find("ResourceHerb");
        objIronBuilding = GameObject.Find("ResourceIron");
        objStoneBuilding = GameObject.Find("ResourceStone");
        scrHouseNodes = objHouseNode.GetComponent<HouseNodes>();

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
            StoneBuilding scrStoneBuilding = objStoneBuilding.GetComponent<StoneBuilding>();
            buildingInfo.stoneBuilt = scrHouseNodes.stoneBuilt;
            buildingInfo.currentStoneHolding = scrStoneBuilding.newScore;
        }
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



