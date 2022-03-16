using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageTextManager : MonoBehaviour
{
    TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();

        // set damage
        int damage =
            (int)ClickerStats.manualClickDamage +
            (int)Random.Range(-ClickerStats.manualClickDamage * .2f, ClickerStats.manualClickDamage * .2f);

        text.text = damage.ToString();
        transform.position = new Vector2(transform.position.x + Random.Range(-75f,75f), transform.position.y + Random.Range(-75f, 75f));
        StartCoroutine(FadeDamageText(0,2));
        StartCoroutine(MoveDamageTextUp(2,1));
    }

    //fades blood away.
    IEnumerator MoveDamageTextUp(float aValue, float aTime)
    {
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Vector2 pos = transform.position;
            float rand = Random.Range(5f, 20f);
            pos.y = Mathf.Lerp(pos.y, pos.y + rand, t);
            transform.position = pos;
            yield return null;
        }
        Destroy(this.gameObject);
    }


    //fades blood away.
    IEnumerator FadeDamageText(float aValue, float aTime)
    {
        yield return new WaitForSecondsRealtime(.2f);
        float alpha = text.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            text.color = newColor;
            yield return null;
        }
        Destroy(this.gameObject);
    }
}
