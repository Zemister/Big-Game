using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsPanel : MonoBehaviour
{
    private bool statsPanelEnabled;
    public GameObject statsPanel;

    public GameObject statExpAndName;
    public GameObject statHealth;
    public GameObject statStrength;
    public GameObject statDexterity;
    public GameObject statDefence;
    public GameObject statAgility;

    void Update()
    {
        OpenAndCloseWindow();
        ShowStats();
        ShowNameAndLevel();
    }

    void OpenAndCloseWindow()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            statsPanelEnabled = !statsPanelEnabled;
        }
        if (statsPanelEnabled == true)
        {
            statsPanel.SetActive(true);
        }
        else
        {
            statsPanel.SetActive(false);
        }
    }

    void ShowStats()
    {
        GameObject player = this.gameObject;
        statHealth.transform.GetChild(0).GetComponent<Text>().text = "Health";
        statHealth.transform.GetChild(1).GetComponent<Text>().text = "" + this.gameObject.GetComponent<Player>().health;

        statStrength.transform.GetChild(0).GetComponent<Text>().text = "Strength";
        statStrength.transform.GetChild(1).GetComponent<Text>().text = "" + this.gameObject.GetComponent<Player>().strength;

        statDexterity.transform.GetChild(0).GetComponent<Text>().text = "Dexterity";
        statDexterity.transform.GetChild(1).GetComponent<Text>().text = "" + this.gameObject.GetComponent<Player>().dexterity;

        statDefence.transform.GetChild(0).GetComponent<Text>().text = "Defence";
        statDefence.transform.GetChild(1).GetComponent<Text>().text = "" + this.gameObject.GetComponent<Player>().defence;

        statAgility.transform.GetChild(0).GetComponent<Text>().text = "Agility";
        statAgility.transform.GetChild(1).GetComponent<Text>().text = "" + this.gameObject.GetComponent<Player>().agility;
    }

    void ShowNameAndLevel()
    {
        statExpAndName.transform.GetChild(2).GetComponent<Text>().text = "" + this.gameObject.GetComponent<Player>().currentLevel;
        statExpAndName.transform.GetChild(0).GetComponent<Text>().text = "" + this.gameObject.GetComponent<Player>().playerName;
    }
}
