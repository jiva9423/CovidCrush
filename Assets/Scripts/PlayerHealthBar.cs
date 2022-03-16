using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    Slider hpBar;
    public GameObject hpBarGreen;
    Image hpBarImage;

    private float nextActionTime = 0.0f;
    private float timeBetweenHeals = 1f;
    // Start is called before the first frame update
    void Start()
    {
        hpBar = GetComponent<Slider>();
        hpBarImage = hpBarGreen.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        hpBar.value = PlayerStats.health / PlayerStats.maxHealth;
        ChangeHpBarColor();
        HealPlayer();
    }

    void ChangeHpBarColor()
    {
        float hp = PlayerStats.health / PlayerStats.maxHealth;
        if (hp >= .5f)
        {
            hpBarImage.color = Color.green;
        }
        else if (hp < .5f && hp >= .25f)
        {
            hpBarImage.color = Color.yellow;
        }
        else
        {
            hpBarImage.color = Color.red;
        }
    }

    void HealPlayer() {

        if (Time.time > nextActionTime)
        {
            nextActionTime = Time.time + timeBetweenHeals;
            if (PlayerStats.health + PlayerStats.playerHealing < PlayerStats.maxHealth)
            {
                PlayerStats.health += PlayerStats.playerHealing;
            }
            else if (PlayerStats.health < PlayerStats.maxHealth)
            {
                PlayerStats.health = PlayerStats.maxHealth;
            }
        }


    }
}
