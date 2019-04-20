using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ResourceDisplay : MonoBehaviour
{
    public Slider healthSlider;
    public Text currentHealth;
    public Text maxHealth;

    private void OnValidate()
    {
        Slider[] slider = GetComponentsInChildren<Slider>();
        healthSlider.value = slider[0].value;
    }
}
