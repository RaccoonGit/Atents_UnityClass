using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    // #. 구성
    // 1. 총알 발사 (리지드 바디의 Velocity)
    // 2. 총알의 속도

    #region this.Components
    public Rigidbody rbody;            // this.Rigidbody 컴포넌트
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
        // 로컬 좌표 발사
        rbody.AddForce(transform.forward * speed, ForceMode.Force);
        // 3초후에 소멸
        Destroy(gameObject, 3.0f);
    }
    #endregion
}
