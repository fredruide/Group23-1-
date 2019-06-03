using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Xml.Serialization;
using System.IO;
public class Saving : MonoBehaviour
{
    public static Saving Instance;

    private GameObject objPlayer;
    private PlayerScript scrPlayer;
    private GameObject objMaterialUI;
    private Material_Counter scrMaterial_UI;



    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Save();
        scrPlayer = objPlayer.GetComponent<PlayerScript>();
        scrMaterial_UI = objMaterialUI.GetComponent<Material_Counter>();
    }

    public void Save()
    {
        Scene scene = SceneManager.GetActiveScene();

        Debug.Log(scene.buildIndex);
    }
}
[Serializable]
public class AllSaving
{
    public int sceneBuildIndexToLoad;
    public int playerPositionX;
    public int playerPositionY;
    public int playerPositionZ;
    public int herb_Material;
    public int stoneMaterial;
    public int ironMaterial;
    public int crystalMaterial;
    public int woodMaterials;
    public int bulletCount;
    public int playerHPotion;
}
