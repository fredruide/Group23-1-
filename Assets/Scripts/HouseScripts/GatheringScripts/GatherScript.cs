using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherScript : MonoBehaviour
{
    //Skrevet af Jakob Vestergaard
    private TextMesh Text;

    private string key = "Test";

    public int newScore { get; set; }
    public float resourceCd = 2f;
    public int resourcePm = 10;

    private float resourceTimeCd;
    private bool resourcePicked = true;
    private int currentScore;
    private int savedScore;

    private void Awake()
    {
        //LoadScore();


        //intSavedScoreID = gameObject.GetInstanceID();
        //stringSavedScoreID = intSavedScoreID.ToString();
        //int Player = PlayerPrefs.GetInt(stringSavedScoreID, savedScore);
    }

    private void Start()
    {
        Text = GetComponent<TextMesh>();
        Text.text = newScore.ToString() + " / 250";
    }

    private void Update()
    {
        resource();

    }

    private void resource()
    {
        if (PlayerPrefs.GetInt(key) == 1 && currentScore <= 240 && newScore <= 240)
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

    /* Gemt til hvis der kommer behøv for at gemme i en .dat fil
    private void saveScore()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/BuildingInfo.dat");

        BuildingInfo buildingInfo = new BuildingInfo();
        // Virker ikke fordi at currentscore ikke er en ting længere
        //buildingInfo.currentStoneHolding = int.Parse(currentScore);
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
            file.Close();
        }
        
    }
    */
}
