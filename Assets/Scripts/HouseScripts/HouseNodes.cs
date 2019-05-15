using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class HouseNodes : MonoBehaviour
{
    //Skrevet af Jakob Vestergaard med design hjælp fra Jonas
    #region Object placing and deletion constructors
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
    #endregion
    #region UI Constructors
    public TextManipulator TextManipulator;

    public GameObject mainCamera1;
    public GameObject overViewCamera;

    public GameObject UI;
    public GameObject buildButton;
    public GameObject deleteButton;
    #endregion

    private void Awake()
    {        
        //BuildingsBuilt();
        TextManipulator = GameObject.FindObjectOfType<TextManipulator>();
    }

    private void Start()
    {
        mainCamera1.SetActive(true);
        overViewCamera.SetActive(false);
        UI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
<<<<<<< HEAD
    {
        //if (Input.GetKeyDown(KeyCode.Delete))
        //{
        //    DeleteBuilding();
        //}
        BuildingSlots();
        Debug.Log(building);
        Debug.Log(herbBuilt);
=======
    {        
        Debug.Log(deleteBuilding);
        //DeleteBuilding();
        BuildingSlots();             
>>>>>>> 2ed5a9271f940d8c61dbd7638f0c48333eac188a
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            overViewCamera.SetActive(true);
            mainCamera1.SetActive(false);

            UI.SetActive(true);

            //Debug.Log("Det triggerede mig");
            //TextManipulator.TextUpdate("Du kan nu bygge en Herbalist, Stone eller Iron indsamler bygning" +
            //    "\n");
            building = true;
        }        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        building = false;
        //TextManipulator.TextUpdate("");
        UI.SetActive(false);

        //Debug.Log(Building)
        mainCamera1.SetActive(true);
        overViewCamera.SetActive(false);
    }

    public void BuildingSlots()
    {               
        if (building)
        {            
            if (Input.GetKeyDown(KeyCode.Alpha1) && !herbBuilt && !deleteBuilding)
            {
                herbBuilt = true;
                Vector3 pos = new Vector3(gridHerbalistX, gridHerbalistY, 9);
                Instantiate(herbalist, pos, Quaternion.identity);                
            }
            if (Input.GetKeyDown(KeyCode.Alpha2) && !stoneBuilt && !deleteBuilding)
            {
                stoneBuilt = true;
                Vector3 pos = new Vector3(gridStoneX, gridStoneY, 9);
                Instantiate(stone, pos, Quaternion.identity);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3) && !ironBuilt && !deleteBuilding)
            {
                ironBuilt = true;
                Vector3 pos = new Vector3(gridIronX, gridIronY, 9);
                Instantiate(iron, pos, Quaternion.identity);
            }
        }
    }

    public void BuildHerbBuilding()
    {
        if (building)
        {
            if (!herbBuilt && !deleteBuilding)
            {
                herbBuilt = true;
                Vector3 pos = new Vector3(gridHerbalistX, gridHerbalistY, 9);
                Instantiate(herbalist, pos, Quaternion.identity);
            }
        }
    }
    public void BuildIronBuilding()
    {
        if (building)
        {
            if (!ironBuilt && !deleteBuilding)
            {
                ironBuilt = true;
                Vector3 pos = new Vector3(gridIronX, gridIronY, 9);
                Instantiate(iron, pos, Quaternion.identity);
            }
        }
    }
    public void BuildStoneBuilding()
    {
        if (building)
        {
            if (!stoneBuilt && !deleteBuilding)
            {
                stoneBuilt = true;
                Vector3 pos = new Vector3(gridStoneX, gridStoneY, 9);
                Instantiate(stone, pos, Quaternion.identity);
            }
        }
    }

    public void DeleteHerbBuilding()
    {
        if (deleteBuilding)
        {
            if (null != GameObject.Find("Herbalist(Clone)"))
            {
                var herbDestroy = GameObject.Find("Herbalist(Clone)");
                Destroy(herbDestroy);
                herbBuilt = false;
            }
        }
    }
    public void DeleteIronBuilding()
    {
        if (null != GameObject.Find("Iron(Clone)"))
        {
            var ironDestroy = GameObject.Find("Iron(Clone)");
            Destroy(ironDestroy);
            ironBuilt = false;
        }
    }
    public void DeleteStoneBuilding()
    {
        if (null != GameObject.Find("Stone(Clone)"))
        {
            var stoneDestroy = GameObject.Find("Stone(Clone)");
            Destroy(stoneDestroy);
            stoneBuilt = false;
        }
    }

    public void DemolishBuildingActivateDeactivate()
    {
        if (building)
        {
            if (deleteBuilding == true)
            {
                buildButton.SetActive(true);
                deleteButton.SetActive(false);
                deleteBuilding = false;
            }
            else if (deleteBuilding == false)
            {
                buildButton.SetActive(false);
                deleteButton.SetActive(true);
                deleteBuilding = true;
            }
        }
    }

    public void BuildingsBuilt()
    {
        if (herbBuilt)
        {            
            Vector3 pos = new Vector3(gridHerbalistX, gridHerbalistY, 9);
            Instantiate(herbalist, pos, Quaternion.identity);
        }
        if (stoneBuilt)
        {
            Vector3 pos = new Vector3(gridStoneX, gridStoneY, 9);
            Instantiate(stone, pos, Quaternion.identity);
        }
        if (ironBuilt)
        {
            Vector3 pos = new Vector3(gridIronX, gridIronY, 9);
            Instantiate(iron, pos, Quaternion.identity);
        }
    }

    //IKKE BRUGT LIGE PT Funktion til at kunne gemme i en .dat fil 
    /*
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
<<<<<<< HEAD

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

   

=======
    */
    //IKKE BRUGT LIGE PT Ikke brugbare funktion længere
    /*
    private void DeleteBuilding()
    {
        //Slet
        if (deleteBuilding)
        {
            //slet af bygninger og en funktion for hver bygning så spilleren kan vælge
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if (null != GameObject.Find("Herbalist(Clone)"))
                {
                    var herbDestroy = GameObject.Find("Herbalist(Clone)");
                    Destroy(herbDestroy);
                    herbBuilt = false;
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (null != GameObject.Find("Stone(Clone)"))
                {
                    var stoneDestroy = GameObject.Find("Stone(Clone)");
                    Destroy(stoneDestroy);
                    stoneBuilt = false;
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                if (null != GameObject.Find("Iron(Clone)"))
                {
                    var ironDestroy = GameObject.Find("Iron(Clone)");
                    Destroy(ironDestroy);
                    ironBuilt = false;
                }
            }
        }            
        objHouseSaving = GameObject.Find("Saving");
        HouseSaving scrHouseSaving = objHouseSaving.GetComponent<HouseSaving>();
        scrHouseSaving.xmlSave();        
    } 
    */
>>>>>>> 2ed5a9271f940d8c61dbd7638f0c48333eac188a
}



