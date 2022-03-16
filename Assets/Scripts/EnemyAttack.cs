using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    private float nextActionTime = 0.0f;
    private float timeBetweenClicks = 1f;


    void Update()
    {
        AttackPlayer();
    }

    void AttackPlayer() {

        if (Time.time > nextActionTime)
        {
            nextActionTime = Time.time + timeBetweenClicks / EnemyStats.hitsPerSecond;

            // attack only if you are at the highest enemy
            if (ShouldEnemyAttack()) {
                if (PlayerStats.health - EnemyStats.enemyDamage > 0 && PlayerStats.alive)
                {
                    // dont subtract it if we are just going to heal it up right away
                    if (PlayerStats.playerHealing <= EnemyStats.enemyDamage) {
                        PlayerStats.health -= EnemyStats.enemyDamage;
                    }
                }
                else
                {
                    PlayerStats.health = PlayerStats.maxHealth;
                    EnemyStats.health = EnemyStats.maxHealth;
                    PlayerStats.gold = PlayerStats.gold / 2;
                    //PlayerStats.alive = false;
                    Debug.Log("Player Dead");
                }
            }
        }
    }

    // checks to see if enemy should be attacking the player.
    bool ShouldEnemyAttack() {
        if (EnemyStats.currentEnemy == EnemyStats.highestEnemyUnlocked)
        {
            return true;
        }
        else {
            return false;
        }
    }
}
