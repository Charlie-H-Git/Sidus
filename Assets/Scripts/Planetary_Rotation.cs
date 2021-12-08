using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planetary_Rotation : MonoBehaviour
{
    public GameObject sun;
    //public GameObject Ankira;
    //public GameObject Zorthan;
    //public GameObject Soprina;
    public GameObject player;
    public float rotationalSpeed = 0f;

    //public GameObject PlayerContainer;
    
    public bool PlayerOrbit;
    private WaypointManager wM;
    private Vector3 zAxis = new Vector3(0, 0, 1);

    private void Start()
    {
        wM = FindObjectOfType<WaypointManager>();
    }

    void FixedUpdate()
    {
        transform.RotateAround(sun.transform.position, zAxis, rotationalSpeed * Time.deltaTime);
        if (wM.currentWaypoint != null && PlayerOrbit)
        {
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }
        else
        {
            
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
            
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject;
            player.gameObject.transform.parent = this.gameObject.transform;
            PlayerOrbit = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject;
            player.gameObject.transform.parent = null;
            PlayerOrbit = false;
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
        }
    }
}