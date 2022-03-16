using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public GameObject rightArrow;
    public GameObject leftArrow;

    private void Start()
    {
        //put the initial values into the list.
        EnemyStats.enemyMaxHealthList.Add(EnemyStats.maxHealth);
        EnemyStats.enemyGoldList.Add((int)(EnemyStats.goldGivenWhenKilled));
        //update whether or not the buttons show.
        CheckRightButton();
        CheckLeftButton();
    }
    private void Update()
    {
        CheckEnemyHealth();
    }

    void CheckEnemyHealth() {
        if (EnemyStats.health <= 0)
        {
            CurrentEnemyKilled();
        }
        EnemyStats.enemyImagesPerRow = EnemyStats.enemyImageFileNames.GetLength(1);
        //checks to see when to go to the next sprite.
        //Debug.Log(EnemyStats.health / EnemyStats.maxHealth + ":" + ( 1 - ((float)1 / (EnemyStats.enemyImagesPerRow+1)) * (EnemyStats.currentEnemyImage + 1)));
        if (EnemyStats.health / EnemyStats.maxHealth <= 1 - ((float)1 / (EnemyStats.enemyImagesPerRow)) * (EnemyStats.currentEnemyImage+1)) {
            GoToNextSprite();
        }
    }

    //when the current enemy is killed this runs.
    void CurrentEnemyKilled() {
        //give gold to player.
        PlayerStats.gold += (int)(EnemyStats.goldGivenWhenKilled * ClickerStats.goldMultiplier);
        //reset the health.
        EnemyStats.health = EnemyStats.maxHealth;
        PlayerStats.health = PlayerStats.maxHealth;
        EnemyStats.currentEnemyImage = 0;//set image back to max hp sprite.
        SwitchSprite.SwitchSpriteImage();
        //checks if current enemy is equivalent to the highest enemy
        if (EnemyStats.currentEnemy == EnemyStats.highestEnemyUnlocked)
        {
            UnlockNextEnemy();
        }
    }

    //will go to next enemy when the button is pressed.
    public void GoToNextEnemy() {
        if (EnemyStats.currentEnemy < EnemyStats.highestEnemyUnlocked) {
            EnemyStats.currentEnemy += 1;
            EnemyStats.maxHealth = EnemyStats.enemyMaxHealthList[EnemyStats.currentEnemy];
            PlayerStats.health = PlayerStats.maxHealth;
            EnemyStats.health = EnemyStats.maxHealth;
            EnemyStats.enemyDamage *= 2;
            EnemyStats.goldGivenWhenKilled = EnemyStats.enemyGoldList[EnemyStats.currentEnemy];
            SwitchSprite.SwitchSpriteImage();//this will update the image.
        }
        //update whether or not the buttons show.
        CheckRightButton();
        CheckLeftButton();
    }

    //will go to previous enemy when button is pressed.
    public void GoToPreviousEnemy() {
        if (EnemyStats.currentEnemy > 0) {
            EnemyStats.currentEnemy -= 1;
            EnemyStats.maxHealth = EnemyStats.enemyMaxHealthList[EnemyStats.currentEnemy];
            EnemyStats.health = EnemyStats.maxHealth;
            PlayerStats.health = PlayerStats.maxHealth;
            EnemyStats.enemyDamage /= 2;
            EnemyStats.goldGivenWhenKilled = EnemyStats.enemyGoldList[EnemyStats.currentEnemy];
            SwitchSprite.SwitchSpriteImage();//this will update the image.
        }
        //update whether or not the buttons show.
        CheckRightButton();
        CheckLeftButton();
    }

    //will go to next Sprite for the current enemy.
    void GoToNextSprite() {
        EnemyStats.enemyImagesPerRow = EnemyStats.enemyImageFileNames.GetLength(1);
        //checks to make sure it hasn't reached the end
        if (EnemyStats.currentEnemyImage < EnemyStats.enemyImagesPerRow)
        {
            EnemyStats.currentEnemyImage += 1;
            SwitchSprite.SwitchSpriteImage();//this will update the image.
        }
        else {
            EnemyStats.currentEnemyImage = 0;
        }
    }

    //unlocks the next enemy.
    void UnlockNextEnemy()
    {
        //checks if highest enemy unlocked is less than total number of enemies
        if (EnemyStats.highestEnemyUnlocked < EnemyStats.enemyNames.Length - 1)
        {
            //we are unlocking a new enemy so store its max hp in the list.
            EnemyStats.enemyMaxHealthList.Add(EnemyStats.maxHealth * EnemyStats.healthIncreaseRate);
            EnemyStats.enemyGoldList.Add((int)(EnemyStats.goldGivenWhenKilled * EnemyStats.goldIncreaseRate));//raises the gold given when killed
            EnemyStats.highestEnemyUnlocked += 1; //unlocks next enemy
        }
        CheckRightButton();
        CheckLeftButton();
    }


    //NEXT and PREV Enemy UI buttons
    void CheckRightButton()
    {
        if (EnemyStats.currentEnemy < EnemyStats.highestEnemyUnlocked)
        {
            rightArrow.SetActive(true);
        }
        else
        {
            rightArrow.SetActive(false);
        }
    }

    void CheckLeftButton()
    {
        if (EnemyStats.currentEnemy > 0)
        {
            leftArrow.SetActive(true);
        }
        else
        {
            leftArrow.SetActive(false);
        }
    }


}
