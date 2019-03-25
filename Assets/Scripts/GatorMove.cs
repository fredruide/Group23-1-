using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatorMove : MonoBehaviour
{
    GameObject playerObject;

    public float Speed;

    public float playerRange;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerObject.transform.position, Speed * Time.deltaTime); 
    }
}
