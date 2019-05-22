using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml.Serialization;
using System.IO;
using System;

public class Material_Counter : MonoBehaviour
{
    private int playerHerbs ;
    private int playerWood ;
    private int playerStone ;
    private int playerIron ;
    private int playerCrystals;
    private Text UIText;

    // Start is called before the first frame update
    void Start()
    {
        UIText = GetComponent<Text>();
    }

    public void CheckForHerb(int HerbCarryOver)
    {
        playerHerbs += HerbCarryOver;
        PrintToUI();
    }
    
    public void CheckForIron(int IronCarryOver)
    {
        playerIron += IronCarryOver;
        PrintToUI();
    }

    public void CheckForStone(int StoneCarryOver)
    {        
        playerStone += StoneCarryOver;
        PrintToUI();
    }
    
    public void PrintToUI()
    {

        UIText.text = "Herbs: " + playerHerbs + "	Wood: " + playerWood + "	Stone: " + playerStone + "	Metal: " + playerIron + " 	Crystal:" + playerCrystals;
    }
    
}


[Serializable]
public class MatValues
{
    public int playerHerbs { get; set; }
    public int playerWood { get; set; }
    public int playerStone { get; set; }
    public int playerMetal { get; set; }
    public int playerCrystals { get; set; }
}