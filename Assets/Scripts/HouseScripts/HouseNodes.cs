using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class HouseNodes : MonoBehaviour
{
    [SerializeField]
    private GameObject herbalist;   
    public bool herbBuilt { get; set; }
    public float gridHerbalistX = 52.5f;
    public float gridHerbalistY = -25.6f;
    [SerializeField]
    private GameObject stone;
    public bool stoneBuilt { get; set; }
    public float gridStoneX = 65.5f;
    public float gridStoneY = 25.6f;

    [SerializeField]
    private GameObject iron;
    public bool ironBuilt { get; set; }
    public float gridIronX = 79.5f;
    public float gridIronY = 25.6f;

    private GameObject objHouseSaving;

    private bool building = false;
    private bool deleteBuilding = false;

    public TextManipulator TextManipulator;

    public GameObject camera1;
    public GameObject camera2;

    //AudioListener camera1AudioLis;
    //AudioListener camera2AudioLis;

    private void Awake()
    {
        //houseSaving = GameObject.FindObjectOfType<HouseSaving>();
        //LoadBuildings();         
        BuildingsBuilt();
        camera1.SetActive(true);
        TextManipulator = GameObject.FindObjectOfType<TextManipulator>();
    }
    
    private void OnApplicationQuit()
    {        
        //SaveBuildings();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Delete))
        //{
        //    DeleteBuilding();
        //}
        BuildingSlots();
        Debug.Log(building);
        Debug.Log(herbBuilt);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            camera2.SetActive(true);
            camera1.SetActive(false);

            //Debug.Log("Det triggerede mig");
            TextManipulator.TextUpdate("Du kan nu bygge en Herbalist, Stone eller Iron indsamler bygning");
            building = true;

            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                deleteBuilding = true;
            }            
        }        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        building = false;
        TextManipulator.TextUpdate("");

        //Debug.Log(Building)
        camera1.SetActive(true);
        camera2.SetActive(false);
    }

    private void BuildingSlots()
    {       
        
        if (building)
        {            
            if (Input.GetKeyDown(KeyCode.Alpha1) && !herbBuilt)
            {
                herbBuilt = true;
                Vector3 pos = new Vector3(gridHerbalistX, gridHerbalistY);
                herbalist = Instantiate(herbalist, pos, Quaternion.identity);
                
            }
            if (Input.GetKeyDown(KeyCode.Alpha2) && !stoneBuilt)
            {
                Vector3 pos = new Vector3(gridStoneX, gridStoneY);
                Instantiate(stone, pos, Quaternion.identity);
                stoneBuilt = true;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3) && !ironBuilt)
            {
                Vector3 pos = new Vector3(gridIronX, gridIronY);
                Instantiate(iron, pos, Quaternion.identity);
                ironBuilt = true;
            }
        }
    }

    public void BuildingsBuilt()
    {
        if (herbBuilt)
        {            
            Vector3 pos = new Vector3(gridHerbalistX, gridHerbalistY);
            Instantiate(herbalist, pos, Quaternion.identity);
        }
        if (stoneBuilt)
        {
            Vector3 pos = new Vector3(gridStoneX, gridStoneY);
            Instantiate(stone, pos, Quaternion.identity);
        }
        if (ironBuilt)
        {
            Vector3 pos = new Vector3(gridIronX, gridIronY);
            Instantiate(iron, pos, Quaternion.identity);
        }
    }

    private void SaveBuildings()
    {
        if (File.Exists(Application.persistentDataPath + "/BuildingInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/BuildingInfo.dat", FileMode.Open);
            BuildingInfo buildingInfo = new BuildingInfo();

            buildingInfo.herbBuilt = herbBuilt;
            print(buildingInfo.herbBuilt + "" + herbBuilt);
            buildingInfo.stoneBuilt = stoneBuilt;
            print(buildingInfo.stoneBuilt);
            buildingInfo.ironBuilt = ironBuilt;
            print(buildingInfo.ironBuilt);

            bf.Serialize(file, buildingInfo);
            file.Close();
        }
        else // IF doesnt exist create new
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/BuildingInfo.dat");
            BuildingInfo buildingInfo = new BuildingInfo();

            buildingInfo.herbBuilt = herbBuilt;
            print(buildingInfo.herbBuilt);
            buildingInfo.stoneBuilt = stoneBuilt;
            print(buildingInfo.stoneBuilt);
            buildingInfo.ironBuilt = ironBuilt;
            print(buildingInfo.ironBuilt);

            bf.Serialize(file, buildingInfo);
            file.Close();
        }
    }

    private void LoadBuildings()
    {
        if (File.Exists(Application.persistentDataPath + "/BuildingInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/BuildingInfo.dat", FileMode.Open);
            BuildingInfo buildingInfo = (BuildingInfo)bf.Deserialize(file);

            herbBuilt = buildingInfo.herbBuilt;
            print(buildingInfo.herbBuilt);
            stoneBuilt = buildingInfo.stoneBuilt;
            print(buildingInfo.herbBuilt);
            ironBuilt = buildingInfo.ironBuilt;
            print(buildingInfo.herbBuilt);
            file.Close();
        }
    }

    ////TODO spillere skal kunne ødelægge huse og er nødvendig for at kunne fjerne data
    //private void DeleteBuilding()
    //{
    //    Destroy(gam);
    //    //Destroy(iron);
    //    //Destroy(stone);
    //    herbBuilt = false;
    //    ironBuilt = false;
    //    stoneBuilt = false;
    //    objHouseSaving = GameObject.Find("Saving");
    //    HouseSaving scrHouseSaving = objHouseSaving.GetComponent<HouseSaving>();
    //    //scrHouseSaving.xmlSave();
    //    if (deleteBuilding)
    //    {
    //        herbBuilt = false;
    //        stoneBuilt = false;
    //        ironBuilt = false;
    //        SaveBuildings();
    //    }
    //}

   

}



