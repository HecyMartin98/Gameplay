using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {
    
    public Camera doorCam;
    public Camera PlayerCam;

    public bool doorOpen;
    bool keyPress;

    public Animator DoorHinge;

    void Start()
    {
        DoorHinge = GetComponent<Animator>();

        doorOpen = false;
        doorCam.enabled = false;
        PlayerCam.enabled = true;
    }
	// Update is called once per frame
	void Update ()
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
           if (Input.GetKey(KeyCode.F) && doorOpen == false)
           {
             Debug.Log("Open");
             DoorHinge.SetBool("DoorOpen", true);
             DoorHinge.SetBool("DoorClosed",false);
             doorOpen = true;
             StartCoroutine(DoorAnimation());
           }

            else if (Input.GetKey(KeyCode.F) && doorOpen == true)
            {
                Debug.Log("Close");
                DoorHinge.SetBool("DoorOpen", false);
                DoorHinge.SetBool("DoorClosed", true);
                doorOpen = false;
                StartCoroutine(DoorAnimation());
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
    IEnumerator DoorAnimation()
    {
        yield return new WaitForSeconds(3.0f);
    }
}
