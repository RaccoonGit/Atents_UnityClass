using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCtrl : MonoBehaviour
{
    // #. ����
    // 1. ȭ�� �߻� (������ �ٵ��� Velocity)
    // 2. ȭ���� �ӵ�

    #region this.Components
    public Rigidbody rbody;            // this.Rigidbody ������Ʈ
    public Transform _player;
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
        _player = GameObject.FindWithTag("Player").transform;
        Vector3 dir = _player.position - (transform.position - new Vector3(0.0f, -2.0f, 0.0f));
        // ���� ��ǥ �߻�
        rbody.AddForce(dir + - transform.up * speed, ForceMode.Force);
        // 3���Ŀ� �Ҹ�
        Destroy(gameObject, 5.0f);
    }
    #endregion
}
