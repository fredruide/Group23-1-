using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class IronBuilding : MonoBehaviour
{
    private TextMesh Text;

    private string key = "Test";

    public int newScore { get; set; }
    public float resourceCd = 2f;
    public int resourcePm = 10;

    private float resourceTimeCd;
    private bool resourcePicked = true;
    private int currentScore;
    //private int loadedScore;
    private int savedScore;

    //private int intSavedScoreID;
    //private string stringSavedScoreID;

    //TODO At bruge information til smide tilbage i vores huse når at vi kan gemme dem og placere dem ordenligt

    private void Awake()
    {
        //LoadScore();
        Text = GetComponent<TextMesh>();
        Text.text = newScore.ToString() + " / 250";

        //intSavedScoreID = gameObject.GetInstanceID();
        //stringSavedScoreID = intSavedScoreID.ToString();
        //int Player = PlayerPrefs.GetInt(stringSavedScoreID, savedScore);
    }

    private void Start()
    {

    }

    private void Update()
    {
        resource();

    }

    private void resource()
    {
        if (PlayerPrefs.GetInt(key) == 1 && currentScore < 240 && newScore < 240)
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

    private void saveScore()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/BuildingInfo.dat");

        BuildingInfo buildingInfo = new BuildingInfo();
        // Virker ikke fordi at currentscore ikke er en ting længere
        //buildingInfo.currentIronHolding = int.Parse(currentScore);
        bf.Serialize(file, buildingInfo);
    }

    private void loadScore()
    {
        if (File.Exists(Application.persistentDataPath + "/BuildingInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/BuildingInfo.dat", FileMode.Open);
            BuildingInfo buildingInfo = (BuildingInfo)bf.Deserialize(file);
            // Virker ikke fordi at currentscore ikke er en ting længere
            //currentScore = buildingInfo.currentIronHolding.ToString();
        }
    }

    private void OnApplicationQuit()
    {
        //saveScore();

        //savedScore = newScore;
        //PlayerPrefs.SetInt(stringSavedScoreID, savedScore);
        //Debug.Log("Vi gemte " + savedScore + " i player prefs under " + stringSavedScoreID + " id'et");

    }
}