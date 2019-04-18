using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsPanel : MonoBehaviour
{
    private bool statsPanelEnabled;
    public GameObject statsPanel;

    void Update()
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
}
