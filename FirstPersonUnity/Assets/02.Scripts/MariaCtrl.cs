using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MariaCtrl : MonoBehaviour
{
    // #. �ʿ�
    // 1. �ִϸ����� ������Ʈ
    // 2. NavMeshgAgent ������Ʈ

    #region this.Components
    public Animator animator;           // this.Animator
    public NavMeshAgent agent;          // this.NavMeshAgent
    #endregion

    #region Public Property
    public Transform playerTr;          // �÷��̾� ��ġ
    public Transform MariaTr;          // �� ��ġ

    public float traceDist = 25.0f;     // ���� ����
    public float attackDist = 5.0f;     // ���� ����

    public MariaDamage mariaDmg;
    #endregion

    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        playerTr = GameObject.FindWithTag("Player").transform;
        MariaTr = GetComponent<Transform>();
    }

    /***********************************************************************
    *                             Unity Events
    ***********************************************************************/
    #region Unity Events

    void Update()
    {
        // if (mariaDmg.isDie == true) return;
        // ���� ������ ���� �ִϸ��̼� ���� ����
        // �÷��̾�� �ڽ��� �Ÿ� �� ��� �޼���
        float dist = Vector3.Distance(playerTr.position, transform.position);

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

    private void FixedUpdate()
    {
        Quaternion rot = Quaternion.LookRotation(playerTr.position - transform.position);
        MariaTr.rotation = Quaternion.Slerp(MariaTr.rotation, rot, Time.deltaTime * 20.0f);
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
    }
    #endregion
}
