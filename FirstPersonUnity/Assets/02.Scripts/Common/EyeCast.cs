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
    private Ray ray;        // ���� ����ü �ڷ���
    private RaycastHit hit;         // ������ � ������Ʈ�� ��Ҵ��� �浹 ������ ��ȯ�ϴ� ����ü
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
