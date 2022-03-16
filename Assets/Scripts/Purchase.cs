using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Purchase : MonoBehaviour
{

    public void UpgradeManualClicker() {
        if (PlayerStats.gold < StoreData.upgradeManualClickerPrice)
        {
            //we dont so return
            return;
        }

        //subtract from our gold.
        PlayerStats.gold -= StoreData.upgradeManualClickerPrice;

        //upgrade clicker
        ClickerStats.manualClickDamage += (int)(ClickerStats.manualClickDamage * 1.5f);
    }

    public void UpgradeAutomaticClicker() {

        if (PlayerStats.gold < StoreData.upgradeAutoClickerPrice)
        {
            //we dont so return
            return;
        }

        //subtract from our gold.
        PlayerStats.gold -= StoreData.upgradeAutoClickerPrice;

        //upgrade clicker
        ClickerStats.automaticClickDamage += (int)(ClickerStats.automaticClickDamage * 1.5f);

    }

    public void UpgradeAutoClickerSpeed() {

        if (PlayerStats.gold < StoreData.upgradeAutoClickerSpeedPrice)
        {
            //we dont so return
            return;
        }

        //subtract from our gold.
        PlayerStats.gold -= StoreData.upgradeAutoClickerSpeedPrice;

        //upgrade clicker  speed
        ClickerStats.autoClicksPerSecond += (int)(ClickerStats.autoClicksPerSecond * 1.5f);

    }

    public void UpgradeGoldMultiplier() {

        if (PlayerStats.gold < StoreData.upgradeGoldMultiplierPrice)
        {
            //we dont so return
            return;
        }

        //subtract from our gold.
        PlayerStats.gold -= StoreData.upgradeGoldMultiplierPrice;

        //upgrade gold multiplier
        ClickerStats.goldMultiplier += (int)(ClickerStats.goldMultiplier * 1.5f);
    }

    public void UpgradePlayerHealth() {
        if (PlayerStats.gold < StoreData.upgradePlayerHealthPrice)
        {
            //we dont so return
            return;
        }

        //subtract from our gold.
        PlayerStats.gold -= StoreData.upgradePlayerHealthPrice;

        //upgrade gold multiplier
        float hpDifference = PlayerStats.maxHealth;
        PlayerStats.maxHealth += (int)(PlayerStats.maxHealth * PlayerStats.playerHealthIncreaseRate);
        //add health added from max health.
        hpDifference = (PlayerStats.maxHealth - hpDifference);
        PlayerStats.health = hpDifference + PlayerStats.health;
    }

    public void UpgradePlayerHealing() {
        if (PlayerStats.gold < StoreData.upgradePlayerHealingPrice)
        {
            //we dont so return
            return;
        }

        //subtract from our gold.
        PlayerStats.gold -= StoreData.upgradePlayerHealingPrice;

        //upgrade healing
        PlayerStats.playerHealing += (int)(PlayerStats.playerHealing * PlayerStats.playerHealingIncreaseRate);
        if (PlayerStats.playerHealing == 0)
        {
            PlayerStats.playerHealing = 1;
        }
    }
}
