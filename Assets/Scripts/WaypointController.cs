using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointController : MonoBehaviour
{
    private PlanetMarket pM;
    private WaypointManager wM;
    public bool arrived = false;
    private CircleCollider2D col;
    // Start is called before the first frame update
    [SerializeField] private PlayerController pC;
    void Start()
    {
        //assigns game object WaypointManager variable name wM
        wM = FindObjectOfType<WaypointManager>();
        //assigns game object CircleCollider to variable name col
        col = GetComponent<CircleCollider2D>();
    }
    

    // a class containing logic to remove the waypoint from the list once its destroyed
    private void OnDestroy()
    {
        //removes the waypoint from the list
        wM.waypoints.Remove(gameObject);
        //changes waypoint exists bool to false
        //pC.waypointExists = false;
    }

    private void Update()
    {
        /*if (arrived = true && pM.playerPresence)
        {
            Destroy(gameObject);
        }*/
        if (!arrived && gameObject != wM.currentWaypoint)
        {
            //Debug.Log("destroying in 15 seconds");
            Destroy(gameObject, 1);
            
        }

        if (!arrived && gameObject == wM.currentWaypoint)
        {
            
        }
    }

    //if collider is triggered enter this statement
    private void OnTriggerStay2D(Collider2D other)
    {
        
        //Debug.Log("trigger activated");
        if (other.gameObject.CompareTag("Player"))
        {
            //returns the arrived value as true
            arrived = true;
            
            Debug.Log("Player has arrived");
            if (other.gameObject.CompareTag("Player") && arrived)
            {
                Destroy(this.gameObject);
            }
            
            
            //destroy this game object
            
            //Debug.Log("waypoint destroyed");
            
            //wM.waypoints.RemoveAt(0);
        }
        //returns arrived bool as false
        
        
    }
    
}
