﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCube : MonoBehaviour
{

    Rigidbody rb;
    private bool isPlayer;
    private string moveInputAxis = "Horizontal";

    void Start ()
    {

        rb = GetComponent<Rigidbody>();
	}
     void Update()
    {
        RaycastHit hit;
        Ray isFloor = new Ray(transform.position, Vector3.down);

        if (Physics.Raycast(isFloor, out hit, 10))
        {
            if (hit.collider.tag != "floor")
            {
                rb.isKinematic = false;
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {

        float moveAxis = Input.GetAxis(moveInputAxis);

        if (other.tag=="Player")
        {
            isPlayer = true;

            if (Input.GetKey(KeyCode.LeftShift))
            {


                transform.Translate(new Vector3(-moveAxis, 0, 0) * 5 * Time.deltaTime);


            }
          

        }


    }
    void OnTriggerExit(Collider other)
    {

       

        if (other.tag.Equals("Player"))
        {
            isPlayer = false;
        }

    }
    void OnGUI()
    {
        if (isPlayer)
        {
            GUI.contentColor = Color.black;
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 10, 100, 20), "Hold L-Shift to push","");
        }
    }
}
