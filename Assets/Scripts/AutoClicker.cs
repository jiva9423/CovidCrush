using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoClicker : MonoBehaviour
{
    private float nextActionTime = 0.0f;
    private float timeBetweenClicks = 1f;

    void Update()
    {
        //runs the auto clicker
        if (Time.time > nextActionTime)
        {
            nextActionTime = Time.time + timeBetweenClicks/ClickerStats.autoClicksPerSecond;
            //make sure the game is in progress
            if (nextActionTime < 0.1f)
            {
                Debug.Log("hit close to 0 " + nextActionTime);
            }
            EnemyStats.health -= ClickerStats.automaticClickDamage;
        }

    }

}
