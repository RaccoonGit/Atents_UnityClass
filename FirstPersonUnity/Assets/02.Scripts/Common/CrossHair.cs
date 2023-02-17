using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossHair : MonoBehaviour
{
    #region this.Components
    private RectTransform thisRectTr;
    #endregion

    #region Private Property
    #endregion

    #region Public Property
    public Image aimImg;

    [Header("조준점 시간 관련 변수")]
    public float startTime = 0.0f;
    public float duration = 0.2f;
    public float minSize = 0.6f;
    public float maxSize = 1.0f;

    [Header("Color 관련 변수")]
    public Color originColor = new Color(1.0f, 1.0f, 1.0f, 0.8f);   // Origin 색상
    public Color gazeColor = new Color(1.0f, 0.0f, 0.0f, 0.8f);     // 조준점이 Enemy에 닿았을 때 색상
    public bool isGaze = false;
    public static CrossHair _crosshair;
    #endregion

    /***********************************************************************
    *                             Unity Events
    ***********************************************************************/
    #region Unity Events
    void Start()
    {
        thisRectTr = GetComponent<RectTransform>();
        aimImg = GetComponent<Image>();
        startTime = Time.time;
        thisRectTr.localScale = Vector3.one * minSize;
        aimImg.color = originColor;
        _crosshair = this;
    }

    // Update is called once per frame
    void Update()
    {
        // 1. 조준점에 Enemy가 겨눠졌을 때
        if (isGaze)
        {
            float t = (Time.time - startTime) / duration;
            thisRectTr.localScale = Vector3.one * Mathf.Lerp(minSize, maxSize, t);
            aimImg.color = gazeColor;
            thisRectTr.Rotate(thisRectTr.forward, 100.0f * Time.deltaTime);
        }
        // 2. 조준점에 Enemy가 겨눠지지 않았을 때
        else
        {
            thisRectTr.localScale = Vector3.one * minSize;
            aimImg.color = originColor;
            startTime = Time.time;
            thisRectTr.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
        }
    }
    #endregion

    /***********************************************************************
    *                            Private Methods
    ***********************************************************************/
    #region Private Methods

    #endregion
}
