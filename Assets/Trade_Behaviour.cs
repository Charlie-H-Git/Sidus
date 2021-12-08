using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trade_Behaviour : MonoBehaviour
{
    private PlayerController pC;
    private PlanetMarket pM;
    // Start is called before the first frame update
    void Start()
    {
        pM = FindObjectOfType<PlanetMarket>();
        pC = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("TradeBehaviour Active");
        pC.tabPrompt.SetActive(true);
        pM.playerPresence = true;
    }

    /*private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pM.playerPresence = false;
        }
        
    }*/
}
