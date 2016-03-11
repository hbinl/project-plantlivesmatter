using UnityEngine;
using System.Collections;

public class h2scr : MonoBehaviour
{
    public GameObject groupx;

    public GameObject lightray1;
    public GameObject lightray2;
    public GameObject exclaim;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(h2Anim());
    }

    // Update is called once per frame
    IEnumerator h2Anim()
    {

        foreach (SpriteRenderer sr in groupx.GetComponentsInChildren<SpriteRenderer>())
        {
            sr.material.color = new Color(
                 sr.material.color.r,
                 sr.material.color.g,
                 sr.material.color.b,
                 0.0f);
        }
        yield return new WaitForSeconds(1.5f);



        // SpriteRenderer lightray1x = lightray1.GetComponent<SpriteRenderer>();
        // SpriteRenderer lightray2x = lightray2.GetComponent<SpriteRenderer>();
        // SpriteRenderer exclaimx = exclaim.GetComponent<SpriteRenderer>();


        foreach (SpriteRenderer sr in groupx.GetComponentsInChildren<SpriteRenderer>())
        {

            float duration = 0.5f;
            float currentTime = 0f;
            float oldAlpha = 0.0f;
            float finalAlpha = 1.0f;

            while (currentTime < duration)
            {
                float alpha = Mathf.Lerp(oldAlpha, finalAlpha, currentTime / duration);
                sr.material.color = new Color(
                    sr.material.color.r,
                    sr.material.color.g,
                    sr.material.color.b,
                    alpha);
                currentTime += Time.deltaTime;
                yield return null;
            }
        }




    }
}
