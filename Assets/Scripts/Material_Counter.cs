using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml.Serialization;
using System.IO;
using System;

public class Material_Counter : MonoBehaviour
{//J.C.
    private int playerHerbs ;
    private int playerWood ;
    private int playerStone ;
    private int playerIron ;
    private int playerCrystals;

    private int playerAmmo;
    private int playerHPotion;

    private Text UIText;
    public Text UIText2;
    // Start is called before the first frame update
    void Start()
    {
        UIText = GetComponent<Text>();
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

        UIText.text = "Herbs: " + playerHerbs + "	Wood: " + playerWood + "	Stone: " + playerStone + "	Metal: " + playerIron + " 	Crystal:" + playerCrystals;
    }

    public void PrintToUI2()
    {
        UIText2.text = "Ammo: " + playerAmmo + "   Potions: " + playerHPotion;
    }

    public int HPotionUsed()
    {
        return playerHPotion;
    }

    public int AmmoUsed()
    {
        return playerAmmo;
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