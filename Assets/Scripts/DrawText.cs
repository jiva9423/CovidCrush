using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DrawText : MonoBehaviour
{
    public Text enemyHealthText;
    public Text goldText;
    public Text autoClickDamagePerSecondText;
    public Text clickDamageText;
    public Text enemyNameText;
    public Text playerHealhText;

    // Update is called once per frame
    void Update()
    {
        enemyHealthText.text = Mathf.Floor(EnemyStats.health).ToString() + "/" + Mathf.Floor(EnemyStats.maxHealth).ToString();
        goldText.text = "G:" + PlayerStats.gold.ToString();
        autoClickDamagePerSecondText.text = "Auto Click Damage: "+Mathf.Floor(ClickerStats.automaticClickDamage * ClickerStats.autoClicksPerSecond).ToString() + " p/s";
        clickDamageText.text = "Avg. Click Damage: " + Mathf.Floor(ClickerStats.manualClickDamage).ToString();
        enemyNameText.text = EnemyStats.enemyNames[EnemyStats.currentEnemy];
        playerHealhText.text = Mathf.Floor(PlayerStats.health).ToString() + "/" + Mathf.Floor(PlayerStats.maxHealth).ToString();
    }

}
