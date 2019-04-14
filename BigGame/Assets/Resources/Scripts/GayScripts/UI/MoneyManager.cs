using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour {

    public Text moneyText;
    public int currentCoins;

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.HasKey("CurrentMoney"))
        {
            currentCoins = PlayerPrefs.GetInt("CurrentMoney");
        } else
        {
            currentCoins = 0;
            PlayerPrefs.SetInt("CurrentMoney", 0);
        }

        moneyText.text = "" + currentCoins;
	}

	// Update is called once per frame
	void Update () {
		
	}

    public void AddCoins(int coinsToAdd)
    {
        currentCoins += coinsToAdd;
        PlayerPrefs.SetInt("CurrentMoney", currentCoins);
        moneyText.text = "" + currentCoins;
    }
}
