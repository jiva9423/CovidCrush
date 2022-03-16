using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int gold = 0;
    public static float maxHealth = 10;
    public static float health = 10;
    public static float playerHealing =  0;
    public static bool alive = true;

    public static float playerHealthIncreaseRate = 1.5f;
    public static float playerHealingIncreaseRate = 1.5f;
}
