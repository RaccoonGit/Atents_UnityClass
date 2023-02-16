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
    // �ݹ� �Լ�
    private void OnDrawGizmos()
    {   // ��ǥ�� �����̳� ���� �׷��ִ� �Լ�
        Gizmos.color = _color;
        Gizmos.DrawSphere(transform.position, _radius);
    }
    #endregion
}
