using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieDamage : MonoBehaviour
{
    // #. ����
    // 1. HP �� ����
    // 2. Die ���
    // 3. �ִϸ��̼� ���� hit, die

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
            Destroy(col.gameObject);                // �Ѿ� 
            Hit(col);

            hp -= 25.0f;                            // HP ����
            if (hp <= 0) Die();                     // HP�� 0�� ��� ��� ó��
        }
    }

    private void Hit(Collision col)
    {
        animator.SetTrigger(hitTrigger);      // �ǰ� �ִϸ��̼�
        var blood = Instantiate(bloodEffect, col.transform.position, Quaternion.identity);      // ����Ʈ ����
        Destroy(blood, 1.5f);                   // ����Ʈ 1.5�� �� �Ҹ�
        // Debug.Log(Hit + "��");
    }
    #endregion

    /***********************************************************************
    *                            Private Methods
    ***********************************************************************/
    #region Private Methods
    private void Die()
    {
        isDie = true;
        GetComponent<NavMeshAgent>().isStopped = true;      // ���� ����
        animator.SetTrigger(dieTrigger);                    // �ǰ� �ִϸ��̼�
        GetComponent<CapsuleCollider>().enabled = false;
    }
    #endregion
}
