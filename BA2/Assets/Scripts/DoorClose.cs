using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorClose : MonoBehaviour {

    public Camera doorCam;
    public Camera PlayerCam;

    private bool doorClosed;

    public Animator DoorHinge;



    void Start()
    {
        DoorHinge = GetComponent<Animator>();

        doorClosed = false;
        doorCam.enabled = false;
        PlayerCam.enabled = true;
    }
    // Update is called once per frame
    void Update()
    {

        //void OnGUI()
        //{
        //    if(enter)
        //    {
        //        GUI.Label(new Rect(Screen.width /2-75,
        //            Screen.height - 100, 150, 30), "Press F to open")
        //    }
        //}
    }

    void OnTriggerEnter(Collider col)
    {

        Debug.Log("collied");
        if (col.tag == "Player")
        {
            doorCam.enabled = true;
            PlayerCam.enabled = false;
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
        {
            if (!doorClosed)
            {
                if (Input.GetKey(KeyCode.F))
                {
                    Debug.Log("Open");
                    DoorHinge.SetBool("DoorClosed", true);
                    doorClosed = true;
                }
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            doorCam.enabled = false;
            PlayerCam.enabled = true;
        }
    }
}
