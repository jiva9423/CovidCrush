using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SwitchSprite : MonoBehaviour
{

    private void Start()
    {
        SwitchSprite.SwitchSpriteImage();
    }

    //Switches sprite image when a certain amount of damage is done.
    public static void SwitchSpriteImage() {
        GameObject enemy = GameObject.FindGameObjectWithTag("enemy");
        SpriteRenderer enemySpriteRender = enemy.GetComponent<SpriteRenderer>();
        SpriteMask enemySpriteMask = enemy.GetComponent<SpriteMask>();
        try
        {
            //its empty.
            if (EnemyStats.enemyImageFileNames.Length == 0) {
                return;
            }
            //when the enemy dies reset currentEnemyImage to 0, same for whenever switched.
            // filename.png should be stored in your Assets/Resources folder
            if (EnemyStats.enemyImageFileNames.GetLength(0) > EnemyStats.currentEnemy) {
                if (EnemyStats.enemyImageFileNames.GetLength(1) > EnemyStats.currentEnemyImage) {
                    string path = EnemyStats.enemyImageFileNames[EnemyStats.currentEnemy, EnemyStats.currentEnemyImage];
                    //loads the sprite image
                    Sprite sprite = Resources.Load<Sprite>(path);
                    //turns image into a sprite texture
                    Texture2D texture = sprite.texture;
                    //turns it into a sprite
                    Sprite spriteEdited = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 50);
                    //render the new sprite
                    enemySpriteRender.sprite = spriteEdited;
                    enemySpriteMask.sprite = spriteEdited;
                }
            }
            
        }
        catch (Exception ex) {
            Debug.LogError(ex.ToString());
        }
        
    }
}
