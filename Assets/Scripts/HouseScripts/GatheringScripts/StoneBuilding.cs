using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class StoneBuilding : MonoBehaviour
{
    private TextMesh Text;

    private string key = "Test";

    public float resourceCd = 2f;
    private float resourceTimeCd;
    private bool resourcePicked = true;

    public int resourcePm = 10;
    private string currentScore = "0";
    private int newScore;

    private int intSavedScoreID;
    private int savedScore;
    private string stringSavedScoreID;

    //TODO At bruge information til smide tilbage i vores huse når at vi kan gemme dem og placere dem ordenligt

    private void Awake()
    {
        loadScore();
        intSavedScoreID = gameObject.GetInstanceID();
        stringSavedScoreID = intSavedScoreID.ToString();
        Text = GetComponent<TextMesh>();

        int Player = PlayerPrefs.GetInt(stringSavedScoreID, savedScore);
    }

    private void OnDestroy()
    {

    }

    private void Update()
    {
        resource();
        //save();
    }

    private void resource()
    {
        if (PlayerPrefs.GetInt(key) == 1 && int.Parse(currentScore) < 240)
        {
            resourceTimeCd = resourceTimeCd - Time.smoothDeltaTime;

            if (resourcePicked)
            {
                currentScore = newScore.ToString();
                //int.TryParse(currentScore, out currentScoreInt);            
                newScore = int.Parse(currentScore) + resourcePm;
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

    private void saveScore()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/BuildingInfo.dat");

        BuildingInfo buildingInfo = new BuildingInfo();

        buildingInfo.currentStoneHolding = int.Parse(currentScore);
        bf.Serialize(file, buildingInfo);
    }

    private void loadScore()
    {
        if (File.Exists(Application.persistentDataPath + "/BuildingInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/BuildingInfo.dat", FileMode.Open);
            BuildingInfo buildingInfo = (BuildingInfo)bf.Deserialize(file);

            currentScore = buildingInfo.currentIronHolding.ToString();
            file.Close();
        }
        
    }

    private void OnApplicationQuit()
    {
        saveScore();

        //savedScore = newScore;
        //PlayerPrefs.SetInt(stringSavedScoreID, savedScore);
        //Debug.Log("Vi gemte " + savedScore + " i player prefs under " + stringSavedScoreID + " id'et");

    }
}

