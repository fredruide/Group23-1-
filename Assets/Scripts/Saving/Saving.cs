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
    public int bonfireNumber;
    private bool loading;
    private GameObject objPlayer;
    private GameObject objMaterialUI;
    private Material_Counter scrMaterial_UI;
    public GameObject player;
    public GameObject fullPlayer;
    public Vector3 position;

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
        Debug.Log(Application.persistentDataPath);
        if (File.Exists(Application.persistentDataPath + "/CharacterSave.xml") == false)
        {
            AllSaving allsaving = new AllSaving();
            XmlSerializer serializer = new XmlSerializer(typeof(AllSaving));
            StreamWriter writer = new StreamWriter(Application.persistentDataPath + "/CharacterSave.xml");
            serializer.Serialize(writer.BaseStream, allsaving);
        }
    }
    //MÅSKE SLETTES
    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Alpha6))
    //    {
    //        load();
    //    }

    //    if (Input.GetKeyDown(KeyCode.Alpha5))
    //    {
    //        Save();
    //    }
    //}

    public void Save(float x, float y, float z)
    {
        AllSaving allsaving = new AllSaving();
        objMaterialUI = GameObject.Find("Material_Counter");
        objPlayer = GameObject.Find("Player");
        scrMaterial_UI = objMaterialUI.GetComponent<Material_Counter>();
        allsaving.sceneBuildIndexToLoad = SceneManager.GetActiveScene().buildIndex;
        allsaving.bonfirePositionX      = x;
        allsaving.bonfirePositionY      = y;
        allsaving.bonfirePositionZ      = z;
        allsaving.herb_Material         = scrMaterial_UI.playerHerbs;
        allsaving.stoneMaterial         = scrMaterial_UI.playerStone;
        allsaving.ironMaterial          = scrMaterial_UI.playerIron;
        allsaving.crystalMaterial       = scrMaterial_UI.playerCrystals;
        allsaving.woodMaterials         = scrMaterial_UI.playerWood;
        allsaving.bulletCount           = scrMaterial_UI.playerAmmo;
        allsaving.playerHPotion         = scrMaterial_UI.playerHPotion;

        XmlSerializer serializer = new XmlSerializer(typeof(AllSaving));
        StreamWriter writer = new StreamWriter(Application.persistentDataPath + "/CharacterSave.xml");
        serializer.Serialize(writer.BaseStream, allsaving);
    }

    public void load()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(AllSaving));
        StreamReader reader = new StreamReader(Application.persistentDataPath + "/CharacterSave.xml");
        AllSaving allSaving = (AllSaving)serializer.Deserialize(reader.BaseStream);

        loading = true;        
        SceneManager.LoadScene(allSaving.sceneBuildIndexToLoad);

        // KIG HER https://answers.unity.com/questions/1174255/since-onlevelwasloaded-is-deprecated-in-540b15-wha.html
        
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    private void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        Debug.Log(loading);
        if (loading)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(AllSaving));
            StreamReader reader = new StreamReader(Application.persistentDataPath + "/CharacterSave.xml");
            AllSaving allSaving = (AllSaving)serializer.Deserialize(reader.BaseStream);

            position = new Vector3(allSaving.bonfirePositionX, allSaving.bonfirePositionY, allSaving.bonfirePositionZ);

            fullPlayer.SetActive(true);
            while (player == null)
            {
                player = GameObject.FindGameObjectWithTag("Player");
            }
            Debug.Log(position);
            player.transform.position = position;
            objMaterialUI = GameObject.Find("Material_Counter");
            objPlayer = GameObject.Find("Player");
            scrMaterial_UI = objMaterialUI.GetComponent<Material_Counter>();

            scrMaterial_UI.CheckForHerb(allSaving.herb_Material);
            scrMaterial_UI.CheckForStone(allSaving.stoneMaterial);
            scrMaterial_UI.CheckForIron(allSaving.ironMaterial);
            scrMaterial_UI.CheckForCrystal(allSaving.crystalMaterial);
            scrMaterial_UI.CheckForWood(allSaving.woodMaterials);
            scrMaterial_UI.CheckForAmmo(allSaving.bulletCount);
            scrMaterial_UI.CheckForHPotion(allSaving.playerHPotion);
            loading = false;
        }
        Debug.Log("Level loaded");
        Debug.Log(scene.name);
        Debug.Log(mode);
    }

    //private void OnLevelWasLoaded(int level)
    //{
        
    //}
}



[Serializable]
public class AllSaving
{
    public int sceneBuildIndexToLoad { get; set; }
    public float bonfirePositionX { get; set; }
    public float bonfirePositionY { get; set; }
    public float bonfirePositionZ { get; set; }
    public int herb_Material { get; set; }
    public int stoneMaterial { get; set; }
    public int ironMaterial { get; set; }
    public int crystalMaterial { get; set; }
    public int woodMaterials { get; set; }
    public int bulletCount { get; set; }
    public int playerHPotion { get; set; }
}
