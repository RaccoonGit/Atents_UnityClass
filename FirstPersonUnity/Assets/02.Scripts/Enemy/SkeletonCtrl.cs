using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeletonCtrl : MonoBehaviour
{
    // 1. ������Ʈ �ʱ�ȭ
    // 2. �÷��̾�� ���̷��� ��ġ
    // 3. ���� ���� ���� ���� ����

    #region this.Components
    public Animator animator;           // this.Animator
    public NavMeshAgent agent;          // this.NavMeshAgent
    #endregion

    #region Public Property
    public Transform skeletonTr;
    public Transform playerTr;
    public float traceDist = 20.0f;
    public float attackDist = 2.5f;

    public SkeletonDamage skeleDmg;
    #endregion

    /***********************************************************************
    *                             Unity Events
    ***********************************************************************/
    #region Unity Events
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        skeletonTr = GetComponent<Transform>();
        playerTr = GameObject.FindWithTag("Player").transform;
        skeleDmg = GetComponent<SkeletonDamage>();
        // �ڵ����� ȸ�� �ϴ� ���� �����Ѵ�.
        // NavMeshAgent���� ȸ������ �ñ�ϱ� �ùٸ� ȸ���� ���� �ʾҴ�.
        // agent.updateRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (skeleDmg.isDie == true) return;
        // ���� ������ ���� �ִϸ��̼� ���� ����
        // �÷��̾�� �ڽ��� �Ÿ� �� ��� �޼���
        float dist = Vector3.Distance(playerTr.position, skeletonTr.position);

        // 1. ���� ���� �ȿ� ��� �Դٸ�
        if (dist <= attackDist)
        {
            AttackMove();
        }
        // 2, ���� ���� �ȿ� ��� �Դٸ�
        else if (dist <= traceDist)
        {
            TraceMove();
        }
        // 3. �ƹ��͵� �ν� ���� ���� ���
        else
        {
            IdleMove();
        }
    }    
    #endregion

    /***********************************************************************
    *                            Private Methods
    ***********************************************************************/
    #region Private Methods
    private void IdleMove()
    {
        agent.isStopped = true;                 // ���� ����
        animator.SetBool("IsAttack", false);    // ���� �ִϸ��̼� ����
        animator.SetBool("IsTrace", false);     // �̵� �ִϸ��̼� ����
    }

    private void TraceMove()
    {
        // ���� �۾�
        animator.SetBool("IsAttack", false);    // ���� �ִϸ��̼� ����
        agent.isStopped = false;                // ���� ����

        // ���� �۾�
        agent.destination = playerTr.position;  // �÷��̾� ��ġ���� �̵�
        animator.SetBool("IsTrace", true);      // �̵� �ִϸ��̼� ���
    }

    private void AttackMove()
    {
        // ���� �۾�
        animator.SetBool("IsTrace", false);     // �̵� �ִϸ��̼� ����
        agent.isStopped = true;                 // ���� ����

        // ���� �۾�
        animator.SetBool("IsAttack", true);     // ���� �ִϸ��̼� ���
                                                // ȸ�� �ڷ���
        Quaternion rot = Quaternion.LookRotation(playerTr.position - transform.position);
        skeletonTr.rotation = Quaternion.Slerp(skeletonTr.rotation, rot, Time.deltaTime * 20.0f);
    }
    #endregion
}
