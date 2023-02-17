using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EyeCast : MonoBehaviour
{
    #region this.Components
    private Transform thisTr;
    #endregion

    #region Private Property
    private Ray ray;        // 광선 구조체 자료형
    private RaycastHit hit;         // 광선이 어떤 오브젝트에 닿았는지 충돌 지점을 반환하는 구조체
    private float dist = 50.0f;
    #endregion

    #region Public Property
    public Image crosshair;
    #endregion

    /***********************************************************************
    *                             Unity Events
    ***********************************************************************/
    #region Unity Events
    void Start()
    {
        thisTr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        RectTransform rectTr = crosshair.GetComponent<RectTransform>();

        ray = new Ray(thisTr.position, thisTr.forward * dist);
        Debug.DrawRay(ray.origin, ray.direction * dist, Color.red);
        if(Physics.Raycast(ray, out hit, dist, 1<<6))
        {
            CrossHair._crosshair.isGaze = true;
        }
        else
        {
            CrossHair._crosshair.isGaze = false;
        }
    }
    #endregion

    /***********************************************************************
    *                            Private Methods
    ***********************************************************************/
    #region Private Methods

    #endregion
}
