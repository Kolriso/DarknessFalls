using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public float hitPoints = 3f;
    public float maxHitPoints = 3f;
    public Image healthBar;

    public float stamina = 2f;
    public float maxStamina = 2f;
    public Image staminaBar;

    public float mana = 1f;
    public float maxMana = 1f;
    public Image manaBar;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Health bar
        healthBar.fillAmount = hitPoints / maxHitPoints;
        // Stamina Bar
        staminaBar.fillAmount = stamina / maxStamina;
        // Mana Bar
        manaBar.fillAmount = mana / maxMana;
    }
}
