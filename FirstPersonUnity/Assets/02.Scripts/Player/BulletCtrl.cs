using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    // #. ����
    // 1. �Ѿ� �߻� (������ �ٵ��� Velocity)
    // 2. �Ѿ��� �ӵ�

    #region this.Components
    public Rigidbody rbody;            // this.Rigidbody ������Ʈ
    #endregion


    #region Public Property
    public float speed = 350.0f;       // �Ѿ��� �ӵ�
    #endregion

    /***********************************************************************
    *                             Unity Events
    ***********************************************************************/
    #region Unity Events
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        // ���� ��ǥ �߻�
        rbody.AddForce(transform.forward * speed, ForceMode.Force);
        // 3���Ŀ� �Ҹ�
        Destroy(gameObject, 3.0f);
    }
    #endregion
}
