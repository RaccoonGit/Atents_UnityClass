using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MonsterDamage : MonoBehaviour
{
    #region this.Components
    private Animator animator;
    public Rigidbody rbody;             // this.Rigidbody
    public CapsuleCollider capCol;      // this.CapsuleCollider
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

    public BoxCollider[] WeaponCol;

    public Canvas UICanvas;
    public Image hpBar;
    public Text hpText;
    #endregion

    /***********************************************************************
    *                             Unity Events
    ***********************************************************************/
    #region Unity Events
    void Start()
    {
        animator = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody>();
        capCol = GetComponent<CapsuleCollider>();
        UICanvas = GetComponentInChildren<Canvas>();

        hp = hpInit;
        hpBar.color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
        hpText.text = hp + " / " + hpInit;
    }
    #endregion

    /***********************************************************************
    *                           Collision Events
    ***********************************************************************/
    #region Collision Events
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == bulletTag)
        {
            Destroy(col.gameObject);                // 총알 
            Hit(col);

            hp -= 10.0f;                            // HP 감소
            hp = Mathf.Clamp(hp, 0, 100);

            hpBar.fillAmount = hp / hpInit;
            if (hpBar.fillAmount <= 0.3f)
                hpBar.color = Color.red;
            else if (hpBar.fillAmount <= 0.5f)
                hpBar.color = Color.yellow;
            hpText.text = hp + " / " + hpInit;

            if (hp <= 0) Die();                     // HP가 0인 경우 사망 처리
        }
    }

    #endregion

    /***********************************************************************
    *                            Private Methods
    ***********************************************************************/
    #region Private Methods
    private void Hit(Collision col)
    {
        animator.SetTrigger(hitTrigger);      // 피격 애니메이션
        var blood = Instantiate(bloodEffect, col.transform.position, Quaternion.identity);      // 이펙트 생성
        Destroy(blood, 1.5f);                   // 이펙트 1.5초 뒤 소멸
        // Debug.Log(Hit + "번");
    }

    private void Die()
    {
        isDie = true;
        GetComponent<NavMeshAgent>().isStopped = true;      // 추적 중지
        animator.SetTrigger(dieTrigger);                    // 피격 애니메이션
        GetComponent<CapsuleCollider>().enabled = false;
        rbody.isKinematic = true;
        GameManager.gameManager.MonsterScore(5);
        UICanvas.enabled = false;
        Destroy(gameObject, 5.0f);
    }

    // 두가지 공격 패턴 중 왼손 공격 판정 시 실행
    private void EnableLeftCollider()
    {
        WeaponCol[0].enabled = true;
        WeaponCol[1].enabled = false;
    }

    // 두가지 공격 패턴 중 오른손 추가 공격이 있는 경우에만 실행
    private void ChangeRightCollider()
    {
        WeaponCol[0].enabled = false;
        WeaponCol[1].enabled = true;
    }

    // 모든 콜라이더를 비활성 시 실행
    private void DisableAllCollider()
    {
        foreach (BoxCollider col in WeaponCol)
        {
            col.enabled = false;
        }
    }
    #endregion

}
