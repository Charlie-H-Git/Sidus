using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CargoScript : MonoBehaviour
{
    [Header("Cargo Settings", order = 1)]
    public int MaximumCapacity = 500;

    public int CurrentCargo = 0;
    public int fuelInCargo = 0;
    public int techInCargo = 0;
    public int oreInCargo = 0;

    public Text fuel;
    public Text tech;
    public Text ore;
    
    
    public bool CargoFull;
    public bool FuelEmpty;
    public bool TechEmpty;
    public bool OreEmpty;    
    private PlanetMarket planetRef;
    
    // Start is called before the first frame update
    void Start()
    {
        StockCheckC();
        planetRef = FindObjectOfType<PlanetMarket>();
    }

    void StockCheckC()
    {
        //assigns cargo quantities to players UI
       fuel.text ="" + fuelInCargo;
        tech.text ="" + techInCargo;
        ore.text ="" + oreInCargo;
        
        //if used cargo space is greater than or equal to the MaximumCapacity then enter the statement
        if (CurrentCargo >= MaximumCapacity)
        {
            //makes CargoFull bool true
            CargoFull = true;
            Debug.Log("Cargo Full");
        }

        //if there is 0 fuel enter the statement 
        if (fuelInCargo == 0)
        {
            //return true on fuel empty bool
            FuelEmpty = true;
        }
        //if there is fuel in cargo 
        else
        {
            //return false on fuel empty bool
            FuelEmpty = false;
        }

       

        if (techInCargo == 0)
        {
            TechEmpty = true;
        }
        else
        {
            TechEmpty = false;
        }

        

        if (oreInCargo == 0)
        {
            OreEmpty = true;
        }
        else
        {
            OreEmpty = false;
        }

        
    }
    
    
    // Update is called once per frame
    void Update()
    {
        //calls upon the StockCheckC class
        StockCheckC();
    
        //Equates the total of each cargo element to give a total count to compare to maximum capacity
        CurrentCargo = fuelInCargo + techInCargo + oreInCargo;
    }

}
