using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    Slider hpBar;
    public GameObject hpBarGreen;
    Image hpBarImage;
    // Start is called before the first frame update
    void Start()
    {
        hpBar = GetComponent<Slider>();
        hpBarImage = hpBarGreen.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        hpBar.value = EnemyStats.health / EnemyStats.maxHealth;
        ChangeHpBarColor();
    }

    void ChangeHpBarColor() {
        float hp = EnemyStats.health / EnemyStats.maxHealth;
        if (hp >= .5f)
        {
            hpBarImage.color = Color.green;
        }
        else if (hp < .5f && hp >= .25f)
        {
            hpBarImage.color = Color.yellow;
        }
        else {
            hpBarImage.color = Color.red;
        }
    }
}
