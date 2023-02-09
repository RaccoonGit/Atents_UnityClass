using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieDamage : MonoBehaviour
{
    // #. 구성
    // 1. HP 값 설정
    // 2. Die 기능
    // 3. 애니메이션 구현 hit, die

    #region this.Components
    private Animator animator;
    #endregion

    #region Private Property
    private float hp = 0.0f;
    private float hpInit = 100.0f;

    #endregion

    #region Public Property
    public string bulletTag = "Bullet";
    public string hitTrigger = "hitTrigger";
    public string dieTrigger = "dieTrigger";
    public GameObject bloodEffect;
    public bool isDie = false;
    #endregion

    /***********************************************************************
    *                             Unity Events
    ***********************************************************************/
    #region Unity Events
    void Start()
    {
        animator = GetComponent<Animator>();
        hp = hpInit;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion

    /***********************************************************************
    *                           Collision Events
    ***********************************************************************/
    #region Collision Events
    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == bulletTag)
        {
            Destroy(col.gameObject);                // 총알 
            Hit(col);

            hp -= 25.0f;                            // HP 감소
            if (hp <= 0) Die();                     // HP가 0인 경우 사망 처리
        }
    }

    private void Hit(Collision col)
    {
        animator.SetTrigger(hitTrigger);      // 피격 애니메이션
        var blood = Instantiate(bloodEffect, col.transform.position, Quaternion.identity);      // 이펙트 생성
        Destroy(blood, 1.5f);                   // 이펙트 1.5초 뒤 소멸
        // Debug.Log(Hit + "번");
    }
    #endregion

    /***********************************************************************
    *                            Private Methods
    ***********************************************************************/
    #region Private Methods
    private void Die()
    {
        isDie = true;
        GetComponent<NavMeshAgent>().isStopped = true;      // 추적 중지
        animator.SetTrigger(dieTrigger);                    // 피격 애니메이션
        GetComponent<CapsuleCollider>().enabled = false;
    }
    #endregion
}
