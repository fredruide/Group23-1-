using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class HerbBuilding : MonoBehaviour
{
    private TextMesh Text;

    private string key = "Test";

    public int newScore;
    public float resourceCd = 2f;
    public int resourcePm = 10;

    private float resourceTimeCd;
    private bool resourcePicked = true;    
    private int currentScore;
    //private int loadedScore;
    private int savedScore;

    private bool peter;

    //private int intSavedScoreID;
    //private string stringSavedScoreID;

    //TODO At bruge information til smide tilbage i vores huse når at vi kan gemme dem og placere dem ordenligt

    private void Awake()
    {
        LoadScore();
        //intSavedScoreID = gameObject.GetInstanceID();
        //stringSavedScoreID = intSavedScoreID.ToString();
        Text = GetComponent<TextMesh>();

        //int Player = PlayerPrefs.GetInt(stringSavedScoreID, savedScore);
    }

    private void Update()
    {
        resource();
        
    }

    private void resource()
    {
        if (PlayerPrefs.GetInt(key) == 1 && currentScore < 240)
        {
            resourceTimeCd = resourceTimeCd - Time.smoothDeltaTime;

            if (resourcePicked)
            {

                currentScore = newScore;
                //int.TryParse(currentScore, out currentScoreInt);            
                newScore = currentScore + resourcePm;
                Text.text = newScore.ToString() + " / 250";
                resourcePicked = false;
                //Debug.Log("et sekund");
            }
            else if (resourceTimeCd <= 0)
            {
                resourceTimeCd = resourceCd;
                resourcePicked = true;
            }
        }
    }

    private void SaveScore()
    {
        if (File.Exists(Application.persistentDataPath + "/BuildingInfo1.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/BuildingInfo1.dat", FileMode.Open);
            BuildingInfo buildingInfo = new BuildingInfo();

            buildingInfo.currentHerbHolding = newScore;
            print(buildingInfo.currentHerbHolding);
            bf.Serialize(file, buildingInfo);
            file.Close();
        }
        else
        { 
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/BuildingInfo1.dat");
            BuildingInfo buildingInfo = new BuildingInfo();

            buildingInfo.currentHerbHolding = newScore;
            
            bf.Serialize(file, buildingInfo);
            file.Close();
        }
    }

    private void LoadScore()
    {
        if (File.Exists(Application.persistentDataPath + "/BuildingInfo1.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/BuildingInfo1.dat", FileMode.Open);
            BuildingInfo buildingInfo = (BuildingInfo)bf.Deserialize(file);

            newScore = buildingInfo.currentHerbHolding;
            //print(loadedScore);
            file.Close();
        }
    }

    private void OnApplicationQuit()
    {
        SaveScore();

        //savedScore = newScore;
        //PlayerPrefs.SetInt(stringSavedScoreID, savedScore);
        //Debug.Log("Vi gemte " + savedScore + " i player prefs under " + stringSavedScoreID + " id'et");

    }
}