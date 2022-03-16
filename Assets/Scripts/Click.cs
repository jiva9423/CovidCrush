using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    private Animator spriteAnimator;
    public GameObject blood;
    public GameObject damageText;
    public Transform canvas;
    
    private void Start()
    {
        spriteAnimator = GetComponent<Animator>();
        spriteAnimator.Play("EnemyIdle");
    }

    private void OnMouseDown()
    {
        // only do damage when upgrade panel is closed
        if (!StoreData.upgradePanelIsOpen) {
            if (EnemyStats.health - ClickerStats.manualClickDamage <= 0)
            {
                EnemyStats.health = 0;
            }
            else
            {
                EnemyStats.health -= ClickerStats.manualClickDamage;
            }
            SpawnBlood();
            SpawnDamageText();
            spriteAnimator.Play("EnemyClicked");
        }
    }

    private void OnMouseUp()
    {
        spriteAnimator.Play("EnemyIdle");
    }

    private void SpawnBlood() {
        Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        Instantiate(blood, worldPosition, transform.rotation);
    }

    private void SpawnDamageText() {
        GameObject test = Instantiate(damageText,canvas);
        test.transform.position = Input.mousePosition;
    }


}
