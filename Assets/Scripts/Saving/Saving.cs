using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Xml.Serialization;
using System.IO;
public class Saving : MonoBehaviour
{
    private Animator fadeAni;
    public static Saving instance;
    public int bonfireNumber;
    private static bool loading;
    private static bool newgame1;
    private GameObject objPlayer;
    private GameObject objMaterialUI;
    private Material_Counter scrMaterial_UI;
    public GameObject player;
    public GameObject fullPlayer;
    public GameObject playerUI;
    public Vector3 position;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        
    }

    void Start()
    {
        //Debug.Log(Application.persistentDataPath);
        newgame1 = false;
        if (File.Exists(Application.persistentDataPath + "/CharacterSave.xml") == false)
        {
            AllSaving allsaving = new AllSaving();
            XmlSerializer serializer = new XmlSerializer(typeof(AllSaving));
            StreamWriter writer = new StreamWriter(Application.persistentDataPath + "/CharacterSave.xml");
            serializer.Serialize(writer.BaseStream, allsaving);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            load();
        }
    }

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
        loading = true;

        XmlSerializer serializer = new XmlSerializer(typeof(AllSaving));
        StreamReader reader = new StreamReader(Application.persistentDataPath + "/CharacterSave.xml");
        AllSaving allSaving = (AllSaving)serializer.Deserialize(reader.BaseStream);       
        SceneManager.LoadScene(allSaving.sceneBuildIndexToLoad);        
        // KIG HER https://answers.unity.com/questions/1174255/since-onlevelwasloaded-is-deprecated-in-540b15-wha.html
        
    }


    public void newgame()
    {
        newgame1 = true;
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
        load();
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
        if (loading)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(AllSaving));
            StreamReader reader = new StreamReader(Application.persistentDataPath + "/CharacterSave.xml");
            AllSaving allSaving = (AllSaving)serializer.Deserialize(reader.BaseStream);

            position = new Vector3(allSaving.bonfirePositionX, allSaving.bonfirePositionY, allSaving.bonfirePositionZ);

            //fullPlayer.SetActive(true);
            while (player == null)
            {
                player = GameObject.FindGameObjectWithTag("Player");
            }
            player.SetActive(true);
            playerUI.SetActive(true);

            if (newgame1)
            {
                position = new Vector3(-44.83f, 5.09f, 3f);
                newgame1 = false;
            }
            else
            {
                position = new Vector3(allSaving.bonfirePositionX, allSaving.bonfirePositionY, allSaving.bonfirePositionZ);
            }

            //Debug.Log(position);
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
        while (fadeAni == null)
        {
            fadeAni = GameObject.FindGameObjectWithTag("Portal").GetComponent<Animator>();
        }        
        fadeAni.SetBool("FadeOut", false);
        Debug.Log("Level loaded");
        Debug.Log(scene.name);
        Debug.Log(mode);
    }
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
