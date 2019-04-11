using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceBuilding : MonoBehaviour
{
    private TextMesh Text;

    private string key = "Test";

    public float resourceCd = 2f;
    private float resourceTimeCd;
    private bool resourcePicked = true;
    //private bool herbTrue = true;

    public int resourcePm = 10;
    private string currentScore = "0";
    private int newScore;
    //private int currentScoreInt;

    private void Start()
    {
        Text = GetComponent<TextMesh>();
    }

    private void Update()
    {
        HerbResource();
        //save();
    }

    void HerbResource()
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
                Debug.Log("et sekund");
            }
            else if (resourceTimeCd <= 0)
            {
                resourceTimeCd = resourceCd;
                resourcePicked = true;
            }
        }
    }
}
