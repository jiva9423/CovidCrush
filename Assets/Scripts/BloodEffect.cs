using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodEffect : MonoBehaviour
{
    private void Start()
    {
        float randSize = Random.Range(-.5f, 1f);
        transform.localScale += new Vector3(randSize,randSize,1);
    }

    // Update is called once per frame
    void Update()
    {
       StartCoroutine(FadeBloodAway(0, 1));
    }

    //fades blood away.
    IEnumerator FadeBloodAway(float aValue, float aTime)
    {
        // get aplha component
        float alpha = transform.GetComponent<SpriteRenderer>().material.color.a;
        //fade to zero alpha in aTime seconds
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            transform.GetComponent<SpriteRenderer>().material.color = newColor;
            yield return null;
        }
        Destroy(this.gameObject);
    }
}
