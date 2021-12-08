using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWallet : MonoBehaviour
{
    public GameObject WinScreen;
    public Text Money;
    public float playerWallet;

    private PlanetMarket planetRef;
    // Start is called before the first frame update
    void Start()
    {
        //calls upon moneyCheck class
        MoneyCheck();
        //assigns PlanetMArket Game object to the variable name planetRef
        planetRef = FindObjectOfType<PlanetMarket>();
    }

    //This class updates the players total money count
    void MoneyCheck()
    {
        Money.text = "£" + playerWallet;
    }
    
    // Update is called once per frame
    void Update()
    {
        //calls on the money check class
        MoneyCheck();
        //if the player wallet sis equal to or greater than 10,0000 enter the statement
        if (playerWallet >= 10000)
        {
            //Activate the You Win UI element
            WinScreen.SetActive(true);
        }
    }
}
