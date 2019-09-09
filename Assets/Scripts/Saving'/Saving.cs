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
    private GameObject objPlayer;
    private GameObject objMaterialUI;
    private Material_Counter scrMaterial_UI;
    public GameObject fullPlayer;
    public GameObject player;
    public GameObject playerUI;
    public GameObject playerCamera;
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
        
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            load();
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Save();
            Debug.Log("Du gemte");
        }
    }

    public void Save()
    {
        AllSaving allsaving = new AllSaving();
        objMaterialUI = GameObject.Find("Material_Counter");
        objPlayer = GameObject.Find("Player");
        scrMaterial_UI = objMaterialUI.GetComponent<Material_Counter>();
        allsaving.sceneBuildIndexToLoad = SceneManager.GetActiveScene().buildIndex;
        allsaving.bonfirePositionX      = gameObject.transform.position.x;
        allsaving.bonfirePositionY      = gameObject.transform.position.y;
        allsaving.bonfirePositionZ      = gameObject.transform.position.z;
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

        position = new Vector3(allSaving.bonfirePositionX, allSaving.bonfirePositionY, allSaving.bonfirePositionZ);

        //Instantiate(playerUI, position, Quaternion.identity);
        //Instantiate(player, position, Quaternion.identity);
        //Instantiate(playerCamera, position, Quaternion.identity);

        

        SceneManager.LoadScene(bonfireNumber);


        StartCoroutine(InstantiateObject());
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
    }

    IEnumerator InstantiateObject()
    {       
        Console.WriteLine(position);
        Instantiate(fullPlayer);
        
        new WaitForSeconds(1);
        yield return null;
    }

    //private void whichBonfire()
    //{
    //    if (bonfireNumber == 1)
    //    {
    //        gameObject.transform.position.x
    //    }
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
