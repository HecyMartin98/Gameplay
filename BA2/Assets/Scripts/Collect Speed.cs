using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectSpeed : MonoBehaviour {

    PlayerMovement PlayerMovement;
    public GameObject Sphere;


    // Use this for initialization
    void Start()
    {
        Sphere.GetComponent<GameObject>();
        Sphere.active = true;
        Sphere.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("collected");
            col.gameObject.GetComponent<PlayerMovement>().speedBoost = true;
            GetComponent<MeshRenderer>().enabled = false;
            Sphere.active = false;
        }
    }
}
