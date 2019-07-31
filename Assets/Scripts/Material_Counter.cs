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
    private int playerHerbs ;
    private int playerWood ;
    private int playerStone ;
    private int playerIron ;
    private int playerCrystals;

    private int playerAmmo;
    private int playerHPotion;
    private TextMeshProUGUI Mats;
    public TextMeshProUGUI Items;

    // Start is called before the first frame update
    void Start()
    {
        Mats = GetComponent<TextMeshProUGUI>();
        PrintToUI();
        PrintToUI2();
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

    public void CheckForCrystal(int CrystalCarryOver)
    {
        playerCrystals += CrystalCarryOver;
        PrintToUI();
    }

    public void CheckForWood(int WoodCarryOver)
    {
        playerWood += WoodCarryOver;
        PrintToUI();
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