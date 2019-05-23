using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

//Skrevet af Jonas C.
public class Drop_Template : MonoBehaviour
{
    public int toCarryOver { get; set; }
    public GameObject objMaterial_Counter;
    public Material_Counter scrMaterial_Counter;

    public Transform target;
    public Rigidbody2D rigidBody;
    public float angleChangeSpeed;
    public float movementSpeed;

    private void Start()
    {
      
    }

    private void FixedUpdate()
    {

        target = GameObject.FindGameObjectWithTag("Player").transform;
        angleChangeSpeed = 500f;
        movementSpeed = 8f;


        Vector2 direction = (Vector2)target.position - rigidBody.position;
        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        rigidBody.angularVelocity = -angleChangeSpeed * rotateAmount;
        rigidBody.velocity = transform.up * movementSpeed;
        
    }

}
