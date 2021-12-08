using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public bool waypointExists;
    private Planetary_Rotation pR;
    private PlanetMarket PlanMark;
    private WaypointManager wM;
    private WaypointController wC;
    public Rigidbody2D rb;
    public float RayDist = 2f;
    public float shipSpeed;
    public GameObject tabPrompt;

    private Vector3 zAxis = new Vector3(0, 0, 1);
    private Vector3 Planet = new Vector3(0, 0, 1);
    
    public GameObject Ankira;
    
    public GameObject Zorthan;
    
    public GameObject Soprina;
    
    public bool ankiraBool;

    public bool zorthanBool;

    public bool soprinaBool;
    // Start is called before the first frame update
    void Start()
    {
        
        //assigns Rigidbody2D to rb
        rb = GetComponent<Rigidbody2D>();
        //if waypointExists bool is true enter the statement
        if (waypointExists)
        {
            //assign waypoint controller to variable wC
            wC = FindObjectOfType<WaypointController>();
        }
        //assigns waypointManager to variable name wM
        wM = FindObjectOfType<WaypointManager>();
        
    }

    

    //On collider trigger enter the statement
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        //Debug.Log("HIT!");
        //if the other object colliding has the tag planet enter the statement
        if (other.CompareTag("Planet"))
        {
            //Activates a prompt for the player
            tabPrompt.SetActive(true);
        }

        if (other.CompareTag("Planet"))
        {
            if (other.gameObject.name == "Ankira")
            {
                ankiraBool = true;
                //Debug.Log("Ankira HIT!");
            }

            if (other.gameObject.name == "Zorthan")
            {
                zorthanBool = true;
                //Debug.Log("Zorthan HIT!");
            }

            if (other.gameObject.name == "Soprina")
            {
                soprinaBool = true;
                //Debug.Log("Soprina HIT!");
            }
        }
    }

    //on collider trigger exit, enter the statement 
    private void OnTriggerExit2D(Collider2D other)
    {
        // if the other game objects tag is planet enter the statement
        if (other.CompareTag("Planet"))
        {
            //Deactivate player prompt UI element
            tabPrompt.SetActive(false);
        }
        if (other.CompareTag("Planet"))
        {
            if (other.gameObject.name == "Ankira")
            {
                ankiraBool = false;
                //Debug.Log("Ankira HIT!");
            }

            if (other.gameObject.name == "Zorthan")
            {
                zorthanBool = false;
                //Debug.Log("Zorthan HIT!");
            }

            if (other.gameObject.name == "Soprina")
            {
                soprinaBool = false;
                //Debug.Log("Soprina HIT!");
            }
        }
        
    }

    void LateUpdate()
    {
       
        
        //=======================Waypoint Navigation============================\\
      //if there is a waypoint game object instantiated enter the statement
      if (wM.currentWaypoint != null )
       {
           waypointExists = true;
           //assigns the first waypoint in the waypoint list to the gameObject variable wP
           GameObject wP = wM.currentWaypoint;

           Debug.Log("Found Waypoint");
           
           //creates a vector from the position of the the first waypoint and the position of the player and finds the difference
           Vector2 direction = wP.transform.position - transform.position;

           //normalizes the direction vector so it only goes between 1 and 0
           var normDirection = direction.normalized;
           //assigns the normalized vector multiplied by time.deltatime multiplied by ship speed 
           // to establish where the player is moving and how fast
           var d1 = normDirection * (Time.deltaTime * shipSpeed);
           //moves the position of the player along the normalized vector from its current position
           rb.MovePosition(d1 + (Vector2)transform.position);
           
           //if the velocity distance is greater than the value of ship speed enter the statement
           if (rb.velocity.magnitude > shipSpeed)
           {
               //assigns the normalized velocity multiplied by the ship speed to the velocity of the rigidbody 
               rb.velocity = rb.velocity.normalized * shipSpeed;
           }
       }

       
    }
}
