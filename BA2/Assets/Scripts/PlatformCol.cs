using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCol : MonoBehaviour {

    public GameObject Player;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == Player)
        {
            Player.transform.parent = transform;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject == Player)
        {
            Player.transform.parent = null;
        }
        
    }
}
