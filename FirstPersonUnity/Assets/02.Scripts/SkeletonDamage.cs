using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class SkeletonDamage : MonoBehaviour
{
    #region this.Components
    public Animator animator;
    public Rigidbody rbody;             // this.Rigidbody
    public CapsuleCollider capCol;      // this.CapsuleCollider
    #endregion

    #region Private Property
    private float hp = 0.0f;
    private float hpInit = 100.0f;

    private string bulletTag = "Bullet";
    private string hitTrigger = "hitTrigger";
    private string dieTrigger = "dieTrigger";
    #endregion

    #region Public Property
    public GameObject bloodEffect;
    public bool isDie = false;

    public Canvas UICanvas;
    public Image hpBar;
    public Text hpText;

    public BoxCollider WeaponCol;
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
            Destroy(col.gameObject);                // �Ѿ� 
            Hit(col);
            hp -= 15.0f;                            // HP ����
            hp = Mathf.Clamp(hp, 0, 100);

            hpBar.fillAmount = hp / hpInit;
            if (hpBar.fillAmount <= 0.3f)
                hpBar.color = Color.red;
            else if (hpBar.fillAmount <= 0.5f)
                hpBar.color = Color.yellow;
            hpText.text = hp + " / " + hpInit;

            if (hp <= 0) Die();
        }
    }
    #endregion

    /***********************************************************************
    *                            Private Methods
    ***********************************************************************/
    #region Private Methods
    private void Hit(Collision col)
    {
        animator.SetTrigger(hitTrigger);      // �ǰ� �ִϸ��̼�
        var blood = Instantiate(bloodEffect, col.transform.position, Quaternion.identity);      // ����Ʈ ����
        Destroy(blood, 1.5f);                   // ����Ʈ 1.5�� �� �Ҹ�
    }
    private void Die()
    {
        isDie = true;
        GetComponent<NavMeshAgent>().isStopped = true;      // ���� ����
        animator.SetTrigger(dieTrigger);                    // �ǰ� �ִϸ��̼�
        GetComponent<CapsuleCollider>().enabled = false;
        rbody.isKinematic = true;
        GameManager.gameManager.SkeletonScore(3);
        UICanvas.enabled = false;
        Destroy(gameObject, 5.0f);
    }

    private void EnableCollider()
    {
        WeaponCol.enabled = true;
    }

    private void DisableCollider()
    {
        WeaponCol.enabled = false;
    }
    #endregion
}
