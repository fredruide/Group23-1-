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
    public bool deleteBuilding = false;
    #endregion
    #region UI Constructors
    public TextManipulator TextManipulator;

    public GameObject mainCamera1;
    public GameObject overViewCamera;

    public Material_Counter Material_CounterScr;

    public GameObject UI;
    public GameObject buildButton;
    public GameObject deleteButton;
    #endregion

    private void Awake()
    {        
        //BuildingsBuilt();
        TextManipulator = GameObject.FindObjectOfType<TextManipulator>();
        mainCamera1 = GameObject.FindGameObjectWithTag("MainCamera");
        Material_CounterScr = GameObject.Find("Material_Counter").GetComponent<Material_Counter>();
    }

    private void Start()
    {
        mainCamera1.SetActive(true);
        overViewCamera.SetActive(false);
        UI.SetActive(false);
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
                Vector3 pos = new Vector3(gridHerbalistX, gridHerbalistY, -10.2f);
                Instantiate(herbalist, pos, Quaternion.identity);                
            }
            if (Input.GetKeyDown(KeyCode.Alpha2) && !stoneBuilt && !deleteBuilding)
            {
                stoneBuilt = true;
                Vector3 pos = new Vector3(gridStoneX, gridStoneY, -10.2f);
                Instantiate(stone, pos, Quaternion.identity);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3) && !ironBuilt && !deleteBuilding)
            {
                ironBuilt = true;
                Vector3 pos = new Vector3(gridIronX, gridIronY, -10.2f);
                Instantiate(iron, pos, Quaternion.identity);
            }
        }
    }

    public void BuildHerbBuilding()
    {
        if (building)
        {
            if (!herbBuilt && !deleteBuilding && Material_CounterScr.playerHerbs > 50)
            {
                herbBuilt = true;
                Material_CounterScr.CheckForHerb(-50);
                Vector3 pos = new Vector3(gridHerbalistX, gridHerbalistY, -10.2f);
                Instantiate(herbalist, pos, Quaternion.identity);
            }
        }
    }
    public void BuildIronBuilding()
    {
        if (building)
        {
            if (!ironBuilt && !deleteBuilding && Material_CounterScr.playerIron > 50)
            {
                ironBuilt = true;
                Material_CounterScr.CheckForIron(-50);
                Vector3 pos = new Vector3(gridIronX, gridIronY, -10.2f);
                Instantiate(iron, pos, Quaternion.identity);
            }
        }
    }
    public void BuildStoneBuilding()
    {
        if (building)
        {
            if (!stoneBuilt && !deleteBuilding && Material_CounterScr.playerStone > 50)
            {
                stoneBuilt = true;
                Material_CounterScr.CheckForStone(-50);
                Vector3 pos = new Vector3(gridStoneX, gridStoneY, -10.2f);
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
                Material_CounterScr.CheckForHerb(25);
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
            Material_CounterScr.CheckForIron(25);
            ironBuilt = false;
        }
    }
    public void DeleteStoneBuilding()
    {
        if (null != GameObject.Find("Stone(Clone)"))
        {
            var stoneDestroy = GameObject.Find("Stone(Clone)");
            Destroy(stoneDestroy);
            Material_CounterScr.CheckForStone(25);
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
            Vector3 pos = new Vector3(gridHerbalistX, gridHerbalistY, -10.2f);
            Instantiate(herbalist, pos, Quaternion.identity);
        }
        if (stoneBuilt)
        {
            Vector3 pos = new Vector3(gridStoneX, gridStoneY, -10.2f);
            Instantiate(stone, pos, Quaternion.identity);
        }
        if (ironBuilt)
        {
            Vector3 pos = new Vector3(gridIronX, gridIronY, -10.2f);
            Instantiate(iron, pos, Quaternion.identity);
        }
    }
}