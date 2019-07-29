using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm_Controller : MonoBehaviour
{
    #region Worm body parts
    public GameObject wormHead;
    public GameObject wormPart1;
    public GameObject wormPart2;
    public GameObject wormPart3;
    public GameObject wormPart4;
    public GameObject wormTail;
    #endregion
    #region WormPositions
    public float headPositionX;
    public float part1PositionX;
    public float tailPositionX;
    //flere kropsdele
    public float wormPositionY;
    #endregion
    public int hp;
    public bool wormActionFinished;
    private int lengthDeteminer;
    private float lengthAdder;
    private int formDeteminer;
    private int formNoDuplicate;
    public float horizontalSpeed = -10f;
    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        //laves true igen når halen slettes
        wormActionFinished = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(horizontalSpeed);
        formDeteminer = Random.Range(0, 2);
        //if (hp <= hp * 0.5)
        //{
        //    horizontalSpeed = horizontalSpeed * 2;
        //}
        if (wormActionFinished)
        {
            WormGeneration();
            wormActionFinished = false;            
        }
    }    

    public void WormGeneration()
    {
        lengthAdder = 14.6f;
        Vector3 pos = new Vector3(headPositionX, wormPositionY, 4);
        Instantiate(wormHead, pos, Quaternion.identity);
        lengthDeteminer = Random.Range(2, 6);
        do
        {
            formNoDuplicate = formDeteminer;
            formDeteminer = Random.Range(0, 4);            
            while (formDeteminer == formNoDuplicate)
            {
                formDeteminer = Random.Range(0, 4);
            }

            if (formDeteminer == 0)
            {
                pos = new Vector3(headPositionX + lengthAdder, wormPositionY, 4);
                Instantiate(wormPart1, pos, Quaternion.identity);
                lengthAdder += 14.6f;
            }
            if (formDeteminer == 1)
            {
                pos = new Vector3(headPositionX + lengthAdder, wormPositionY, 4);
                Instantiate(wormPart2, pos, Quaternion.identity);
                lengthAdder += 14.6f;
            }
            if (formDeteminer == 2)
            {
                pos = new Vector3(headPositionX + lengthAdder, wormPositionY, 4);
                Instantiate(wormPart3, pos, Quaternion.identity);
                lengthAdder += 14.6f;
            }
            if (formDeteminer == 3)
            {
                pos = new Vector3(headPositionX + lengthAdder, wormPositionY, 4);
                Instantiate(wormPart4, pos, Quaternion.identity);
                lengthAdder += 14.6f;
            }            
            lengthDeteminer--;
        } while (lengthDeteminer > 0);

        pos = new Vector3(headPositionX + lengthAdder, wormPositionY, 4);
        Instantiate(wormTail, pos, Quaternion.identity);
    }
}
