using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGizmos : MonoBehaviour
{
    #region Public Property
    public Color _color = Color.green;
    public float _radius = 0.5f;
    #endregion

    /***********************************************************************
    *                             Unity Events
    ***********************************************************************/
    #region Unity Events
    // 콜백 함수
    private void OnDrawGizmos()
    {   // 좌표에 색상이나 선을 그려주는 함수
        Gizmos.color = _color;
        Gizmos.DrawSphere(transform.position, _radius);
    }
    #endregion
}
