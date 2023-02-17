using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinimapImgEnable : MonoBehaviour
{
    public Image img;
    float timePrev = 0.0f;
    void Start()
    {
        img = GetComponent<Image>();
        timePrev = Time.time;
        // StartCoroutine(Flicker());
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - timePrev > 0.5f)
        {
            img.enabled = true;
        }
        else
        {
            img.enabled = false;

            timePrev = Time.time;
        }
    }

    private IEnumerator Flicker()
    {
        while(true)
        {
            img.enabled = true;
            yield return new WaitForSeconds(1.0f);
            img.enabled = false;
            yield return new WaitForSeconds(0.5f);
            yield return null;
        }
    }
}
