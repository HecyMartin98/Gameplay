using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCont : MonoBehaviour {

    public int smooth = 3;
    public float speedH = 2.0f;
    public float speedV = 2.0f;
    public Transform player;

    
    private float camX = 0f;
    private float camZ = 7f;
    private float camY = -4f;
    private float yaw = 0.0f;
    private float pitch = 0.0f;

    void Update()
    {
        transform.LookAt(player);
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
    void LateUpdate()
    {
        float xDist = player.transform.position.x - camX;
        float yDist = player.transform.position.y - camY;
        float zDist = player.transform.position.z - camZ;

        transform.position = Vector3.Lerp(transform.position, new Vector3(xDist, yDist, zDist), smooth * Time.deltaTime);
    }
}
