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
    public int p;
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

        
        objPlayer = GameObject.Find("Player");
        objMaterialUI = GameObject.Find("Material_Counter");
        scrPlayer = objPlayer.GetComponent<PlayerScript>();
        scrMaterial_UI = objMaterialUI.GetComponent<Material_Counter>();
        Debug.Log(Application.persistentDataPath);

        Save();

    }

    public void Save()
    {
        AllSaving allsaving = new AllSaving();
        //allsaving.sceneBuildIndexToLoad = SceneManager.GetActiveScene().buildIndex;
        allsaving.playerPositionX = objPlayer.transform.position.x;
        //allsaving.playerPositionY = objPlayer.transform.position.y;
        //allsaving.playerPositionZ = objPlayer.transform.position.z;


        XmlSerializer serializer = new XmlSerializer(typeof(BuildingInfo));
        StreamWriter writer = new StreamWriter(Application.persistentDataPath + "/CharacterSave.xml");
        serializer.Serialize(writer.BaseStream, allsaving);
    }
}
[Serializable]
public class AllSaving
{
    //public int sceneBuildIndexToLoad { get; set; }
    public float playerPositionX { get; set; }
    //public float playerPositionY;
    //public float playerPositionZ;
    //public int herb_Material;
    //public int stoneMaterial;
    //public int ironMaterial;
    //public int crystalMaterial;
    //public int woodMaterials;
    //public int bulletCount;
    //public int playerHPotion;
}
