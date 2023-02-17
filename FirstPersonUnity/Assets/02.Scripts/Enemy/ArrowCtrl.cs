using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCtrl : MonoBehaviour
{
    // #. 구성
    // 1. 화살 발사 (리지드 바디의 Velocity)
    // 2. 화살의 속도

    #region this.Components
    public Rigidbody rbody;            // this.Rigidbody 컴포넌트
    public Transform _player;
    #endregion


    #region Public Property
    public float speed = 350.0f;       // 총알의 속도
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
        // 로컬 좌표 발사
        rbody.AddForce(dir + - transform.up * speed, ForceMode.Force);
        // 3초후에 소멸
        Destroy(gameObject, 5.0f);
    }
    #endregion
}
