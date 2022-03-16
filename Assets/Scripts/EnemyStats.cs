using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public static float health = 100;
    public static float maxHealth = 100;
    public static float healthIncreaseRate = 10f;

    public static int goldGivenWhenKilled = 100;
    public static float goldIncreaseRate = 1.1f;


    public static int currentEnemy = 0;//for sprite index
    public static int currentEnemyImage = 0;//for sprite imageindex
    public static int enemyImagesPerRow = 6;
    public static int highestEnemyUnlocked = 0;//the highest guy you have unlocked.

    public static float healthToHeal = 10;//NOT CURRENTLY USED.
    public static int enemyVitality = 10;//NOT CURRENTLY USED.
    public static int enemyDamage = 1;//NOT CURRENTLY USED.


    public static int hitsPerSecond = 1;//the auto hit rate.
    public static List<float> enemyMaxHealthList = new List<float>();//stores enemy max health at each stage
    public static List<int> enemyGoldList = new List<int>();//stores enemy gold dropped at each stage

    //name of each of the enemies.
    public static string[] enemyNames = new string[]
    { "Common cold","Influenza", "COVID-19", "Spanish Flu","Black Plague"};

    //the row indicates the enemy, the column indicates the stage the enemy is at.
    //the png file names.
    public static string[,] enemyImageFileNames = new string[,]
        {{"commoncold","commoncold","commoncold","commoncold","commoncold","commoncold"},
            {"influenza","influenza","influenza","influenza","influenza","influenza"},
            {"covid","covid","covid","covid","covid","covid"},
            {"spanishflu","spanishflu","spanishflu","spanishflu","spanishflu","spanishflu"},
            {"blackplague","blackplague","blackplague","blackplague","blackplague","blackplague"}
        };
}
