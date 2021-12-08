using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetMarket : MonoBehaviour
{
    private CargoScript cargo;
    public bool playerPresence;
    [Header("Trade Mode", order = 1)]
    public bool sellMode = false;
    public bool buyMode = false;
   
    [Header("UI Game Objects", order = 2)]
    //public game object references
    public GameObject buyModeText;
    public GameObject sellModeText;
    public GameObject sellText;
    public GameObject buyText;
    public GameObject PlanetaryStock;
    public Text fuelCount;
    public Text techCount;
    public Text oreCount;
    
    //private game object reference
    private PlayerWallet playMoney;
    //private integer variable
    private int modeSwitch = 0;
    
    [Header("Planetary Stock", order = 3)]
    public int FuelStock = 150;

    public int TechStock = 500;

    public int OreStock = 506;

    [Header("Planetary Prices", order = 4)]
    [Range(0f, 50f)]public float FuelPrice = 1.5f;

    [Range(0f, 50f)]public float TechPrice = 5.5f;

    [Range(0f, 50f)]public float OrePrice = 2.4f;
    
    // Start is called before the first frame update
    void Start()
    {
        //Assigns the game object PlayerWallet to the variable name playMoney
        playMoney = FindObjectOfType<PlayerWallet>();
        //Assigns the game object CargoScript to the variable name cargo
         cargo = FindObjectOfType<CargoScript>();
         //calls on the class StockCheck
        StockCheck();
    }

    void StockCheck()
    {
        //Assigns the values of Fuel, Tech and OreStock to UI elements
        fuelCount.text = "" + FuelStock;
        techCount.text = "" + TechStock;
        oreCount.text = "" + OreStock;
    }

    
    
    void tradeMode()
    {
        //If the playerPresence Bool is true and the Key TAB is pressed enter the statement
        if (playerPresence && Input.GetKeyDown(KeyCode.Tab))
        {
            //increments to integer modeSwitch by 1
            modeSwitch++;
            // if modeSwitch is comparative to 1 enter the statement
            if (modeSwitch == 1)
            {
                //calls up the class SellMode
                SellMode();
            }
            // if modeSwitch is greater than or equal to 2 enter the statement
            if (modeSwitch == 2)
            {
                //calls upon the class BuyMode
                BuyMode();
                //Define the integer modeSwitch as 0
                
            }

            if (modeSwitch >= 3)
            {
                neutral();
                modeSwitch = 0;
            }
        }
    }
    //Updates every Frame
    void Update()
    {
        //if playerPrescence is true enter the statement
        if (playerPresence)
        {
            Debug.Log("enntering trade mode");
            //calls upon the class tradeMode
            tradeMode();
        }
        //Calls on the class StockCheck
        StockCheck();
        //Calls on the class CloseUI
        CloseUI();

        //If the Cargo is not full and buyMode Bool is true the enter the statement
        if (!cargo.CargoFull && buyMode)
        {
            //if the the 1 key is pressed
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                //Subtract the cost of 1 fuel from the players wallet total
                playMoney.playerWallet = playMoney.playerWallet - FuelPrice;
                //Decrement by 1 on the planets fuel stock
                FuelStock --;
                //Increment by 1 on the players fuel stock
                cargo.fuelInCargo ++;
            }

            //if the the 1 key is pressed
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                //Subtract the cost of 1 Tech from the players wallet total
                playMoney.playerWallet = playMoney.playerWallet - TechPrice;
                //Decrement by 1 on the planets tech stock
                TechStock --;
                //Increment by one on the players Tech Stock
                cargo.techInCargo ++;
                Debug.Log("Bought 1 Tech");
            }

            //if the the 1 key is pressed
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                //Subtract the cost of 1 ore from the players wallet total
                playMoney.playerWallet = playMoney.playerWallet - OrePrice;
                //Decrement by 1 on the planets Ore Stock
                OreStock --;
                //Increment by 1 on the players Ore Stock
                cargo.oreInCargo ++;
                Debug.Log("Bought 1 Ore");
            }
        }

        //if sell mode bool is true enter the statement
        if (sellMode)
        {
            //if Fuel isn't empty and the 1 key is pressed then enter the statement
            if (!cargo.FuelEmpty && Input.GetKeyDown(KeyCode.Alpha1))
            {
                //Add the price of fuel to the players wallet total
                playMoney.playerWallet = playMoney.playerWallet + FuelPrice;
                //Increments the planets fuel stock by 1
                FuelStock++;
                //Decrements players fuel stock by 1
                cargo.fuelInCargo--;
                Debug.Log("Sold 1 Fuel");
            }
            //if Tech isn't empty and the 2 key is pressed then enter the statement
            if (!cargo.TechEmpty && Input.GetKeyDown(KeyCode.Alpha2))
            {
                //add the price of 1 tech to the players wallet total
                playMoney.playerWallet = playMoney.playerWallet + TechPrice;
                //Increments the planets tech stock by 1
                TechStock++;
                //Decrements players tech stock by 1
                cargo.techInCargo--;
                Debug.Log("Sold 1 Tech");
            }
            //if Ore isn't empty and the 3 key is pressed then enter the statement
            if (!cargo.OreEmpty && Input.GetKeyDown(KeyCode.Alpha3))
            {
                //Adds the price of 1 ore to the players wallet total
                playMoney.playerWallet = playMoney.playerWallet + OrePrice;
                //Increments the planets ore stock by 1
                OreStock++;
                //Decrements the players ore stock by 1
                cargo.oreInCargo--;
                Debug.Log("Sold 1 Ore");
            } 
                
        }
    }
    

    // A class containing logic for closing the ui when the player leaves
    void CloseUI()
    {
        //if the playerPresence bool is false enter the statment 
        if (!playerPresence)
        {
            neutral();
            //Deactivates all the UI elements in the hierarchy
            PlanetaryStock.SetActive(false);
            buyText.SetActive(false);
            buyModeText.SetActive(false);
            sellText.SetActive(false);
            sellModeText.SetActive(false);
        }
    }
    
    //A class that manages the UI Logic
    void neutral()
    {
        buyMode = false;
        sellMode = false;
        PlanetaryStock.SetActive(false);
        buyText.SetActive(false);
        buyModeText.SetActive(false);
        sellText.SetActive(false);
        sellModeText.SetActive(false);
    }
    
    // A class that manages the UI appearance for SellMode
    void SellMode()
    {
        PlanetaryStock.SetActive(true);
        buyText.SetActive(false);
        buyModeText.SetActive(false);
        buyMode = false;
        sellMode = true;
        sellText.SetActive(true);
        sellModeText.SetActive(true);
    }
    //A class that manages the UI appearance for BuyMode
    void BuyMode()
    {
        PlanetaryStock.SetActive(true);
        sellText.SetActive(false);
        sellModeText.SetActive(false);
        buyMode = true;
        sellMode = false;
        buyText.SetActive(true);
        buyModeText.SetActive(true);
    }
    
    // A private class that is executed when the Collider of the planet is triggered
    private void OnTriggerEnter2D(Collider2D other)
    {
        //if the collider is triggered by a game object with the player tag then enter the statement
        if (other.CompareTag("Player"))
        {
            // Sets playerpresence bool to true
            playerPresence = true;
            
        }
        
        //Debug.Log("Fuel Stock: "FuelStock);
        //Debug.Log("Ore Stock: "OreStock);
        //Debug.Log("Tech Stock: "TechStock);
    }

    //A private class that is executed when the collider of the planet is no longer triggered
    private void OnTriggerExit2D(Collider2D other)
    {
        //if the collider is triggered by a game object with the player tag then enter the statement
        if (other.CompareTag("Player"))
        {
            //Sets playerpresence bool to false
            playerPresence = false; //SET TO FALSE TO ALLOW FOR TRADE_BEHAVIOUR TO ASSIGN FALSE VALUE
            //if the bool buy mode is true enter the statement
            if (buyMode)
            {
                //Deactivate UI elements
                buyText.SetActive(false);
                buyModeText.SetActive(false);
            }
            //if the bool sell mode is true enter the statement 
            if (sellMode)
            {
                //Deactivate UI elements
                sellModeText.SetActive(false);
                sellText.SetActive(false);
            }
            
        }
    }
}
