using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPanelInput : MonoBehaviour
{
    [SerializeField] GameObject statsGameObject;
    [SerializeField] StatToolTip statToolTip;
    [SerializeField] GameObject inventoryGameObject;
    [SerializeField] ItemToolTip itemToolTip;

    [SerializeField] KeyCode[] toggleInventoryKeys;
    [SerializeField] KeyCode[] toggleStatsKeys;

    void Update()
    {
        ToggleInventoryPanel();
        ToggleStatsPanel();
    }

    public void ToggleInventoryPanel()
    {
        for (int i = 0; i < toggleInventoryKeys.Length; i++)
        {
            if (Input.GetKeyDown(toggleInventoryKeys[i]))
            {
                inventoryGameObject.SetActive(!inventoryGameObject.activeSelf);
                itemToolTip.HideTooltip();
                break;
            }
        }
    }

    public void ToggleStatsPanel()
    {
        for (int i = 0; i < toggleStatsKeys.Length; i++)
        {
            if (Input.GetKeyDown(toggleStatsKeys[i]))
            {
                statsGameObject.SetActive(!statsGameObject.activeSelf);
                statToolTip.HideTooltip();
                break;
            }
        }
    }

    public void ButtonToggleStatsPanel()
    {
        statsGameObject.SetActive(!statsGameObject.activeSelf);
    }
}
