using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailMover : MonoBehaviour {
    
    public Rail rail;
    public Transform lookAt;
    public bool smoothMove = true;
    public float movespeed = 5.0f;

    private Transform thisTransform;
    private Vector3 lastPos;

    private void Start()
    {
        thisTransform = transform;
        lastPos = thisTransform.position;
    }
    private void Update()
    {
        if (smoothMove)
        {
            lastPos = Vector3.Lerp(lastPos, rail.CharacterPos(lookAt.position), Time.deltaTime);
            thisTransform.position = lastPos;
        }
        else
        {
           thisTransform.position = rail.CharacterPos(lookAt.position);
        }
        
        thisTransform.LookAt(lookAt.position);
    }

}
