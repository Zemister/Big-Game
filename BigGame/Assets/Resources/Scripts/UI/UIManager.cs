using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Slider healthBar;
    public Text HPText;
    public PlayerResourceManager player;

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
        healthBar.maxValue = player.maxHealth;
        healthBar.value = player.currentHealth;
        HPText.text = "HP: " + player.currentHealth + "/" + player.maxHealth;
    }
}
