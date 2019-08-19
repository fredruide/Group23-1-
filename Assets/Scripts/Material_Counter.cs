using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml.Serialization;
using System.IO;
using System;
using TMPro;

public class Material_Counter : MonoBehaviour
{//J.C.
    public int playerHerbs ;
    public int playerWood ;
    public int playerStone ;
    public int playerIron ;
    public int playerCrystals;
    
    public int playerAmmo;
    public int playerHPotion;
    private TextMeshProUGUI Mats;
    public TextMeshProUGUI Items;

    private GameObject objScoreCounter;
    private ScoreCounter scrScoreCounter;

    private HouseNodes houseNodes;
    private bool DeleteMode = false;

    // Start is called before the first frame update
    void Awake()
    {
        Mats = GetComponent<TextMeshProUGUI>();

        objScoreCounter = GameObject.Find("ScoreCounter");
        scrScoreCounter = objScoreCounter.GetComponent<ScoreCounter>();
        if(GameObject.Find("HouseNode").GetComponent<HouseNodes>() != null)
            houseNodes = GameObject.Find("HouseNode").GetComponent<HouseNodes>();
        PrintToUI();
        PrintToUI2();
    }

    public void CheckForHerb(int HerbCarryOver)
    {
        playerHerbs += HerbCarryOver;
        PrintToUI();

        DeleteMode = houseNodes.deleteBuilding;
        if (HerbCarryOver > 0 && DeleteMode == false)
        {
            scrScoreCounter.AddScore(HerbCarryOver);
            DeleteMode = false;
        }
    }
    
    public void CheckForIron(int IronCarryOver)
    {
        playerIron += IronCarryOver;
        PrintToUI();

        DeleteMode = houseNodes.deleteBuilding;
        if (IronCarryOver > 0 && DeleteMode == false)
        {
            scrScoreCounter.AddScore(IronCarryOver);
            DeleteMode = false;
        }
    }

    public void CheckForStone(int StoneCarryOver)
    {        
        playerStone += StoneCarryOver;
        PrintToUI();

        DeleteMode = houseNodes.deleteBuilding;
        if (StoneCarryOver > 0 && DeleteMode == false)
        {
            scrScoreCounter.AddScore(StoneCarryOver);
            DeleteMode = false;
        }
    }

    public void CheckForCrystal(int CrystalCarryOver)
    {
        playerCrystals += CrystalCarryOver;
        PrintToUI();

        DeleteMode = houseNodes.deleteBuilding;
        if (CrystalCarryOver > 0 && DeleteMode == false)
        {
            scrScoreCounter.AddScore(CrystalCarryOver * 10);
            DeleteMode = false;
        }
    }

    public void CheckForWood(int WoodCarryOver)
    {
        playerWood += WoodCarryOver;
        PrintToUI();

        DeleteMode = houseNodes.deleteBuilding;
        if (WoodCarryOver > 0 && DeleteMode == false)
        {
            scrScoreCounter.AddScore(WoodCarryOver);
            DeleteMode = false;
        }
    }

    public void CheckForAmmo(int AmmoCarryOver)
    {
        if (playerAmmo < 10 || AmmoCarryOver == -1)
        {
            playerAmmo += AmmoCarryOver;
            PrintToUI2();
        }
    }

    public void CheckForHPotion(int HPotionCarryOver)
    {
        if (playerHPotion < 5 || HPotionCarryOver == -1)
        {
            playerHPotion += HPotionCarryOver;
            PrintToUI2();
        }

    }

    public void PrintToUI()
    {
        Mats.text = "  <sprite=\"roguelikeitems\" index=170>: " + playerHerbs + "	  <sprite=\"roguelikeitems\" index=80>: " + playerWood + "     <sprite=\"rock\" index=0>: " + playerStone + "     <sprite=\"roguelikeitems\" index=67>: " + playerIron + "     <sprite=\"roguelikeitems\" index=45>: " + playerCrystals;
    }

    public void PrintToUI2()
    {
        Items.text = "<sprite=\"SS2\" index=8>: " + playerAmmo + "  <sprite=\"roguelikeitems\" index=63>: " + playerHPotion;
    }

    public int HPotionUsed()
    {
        return playerHPotion;
    }

    public int AmmoUsed()
    {
        return playerAmmo;
    }

    public void Death()
    {
        playerCrystals = 0;
        playerHerbs = 0;
        playerIron = 0;
        playerStone = 0;
        playerWood = 0;
        PrintToUI();
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


    public int playerAmmo { get; set; }
    public int playerHPotion { get; set; }
}