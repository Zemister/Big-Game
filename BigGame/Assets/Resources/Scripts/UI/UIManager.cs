using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Slider healthBar;
    public Text HPText;
    public Player playerHealth;

    private static bool UIExists;

    void Start()
    {
        if (!UIExists)
        {
            UIExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        healthBar.maxValue = playerHealth.playerMaxHealth;
        healthBar.value = playerHealth.playerHealth;
        HPText.text = "HP: " + playerHealth.playerHealth + "/" + playerHealth.playerMaxHealth;
    }
}
