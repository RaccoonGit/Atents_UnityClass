using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// 1. ������Ʈ �ʱ�ȭ
// 2. �÷��̾� ��ġ�� �ڽ�(����)�� ��ġ�� �˾ƾ��Ѵ�
// 3. ���� ������ ���� ������ ���� �ൿ�Ѵ�.
public class ZombieCtrl : MonoBehaviour
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
    public Transform ZombieTr;          // �� ��ġ

    public float TraceDist = 20.0f;     // ���� ����
    public float attackDist = 3.0f;     // ���� ����
    #endregion

    /***********************************************************************
    *                             Unity Events
    ***********************************************************************/
    #region Unity Events
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        playerTr = GameObject.FindWithTag("Player").transform;
        ZombieTr = GetComponent<Transform>();
    }

    void Update()
    {
        // �÷��̾�� �ڽ��� �Ÿ� �� ��� �޼���
        float dist = Vector3.Distance(playerTr.position, ZombieTr.position);

        // 1. ���� ���� �ȿ� ��� �Դٸ�
        if(dist<=attackDist)
        {
            // ���� �۾�
            animator.SetBool("IsTrace", false);     // �̵� �ִϸ��̼� ����
            agent.isStopped = true;                 // ���� ����

            // ���� �۾�
            animator.SetBool("IsAttack", true);     // ���� �ִϸ��̼� ���
        }
        // 2, ���� ���� �ȿ� ��� �Դٸ�
        else if(dist <= TraceDist)
        {
            // ���� �۾�
            animator.SetBool("IsAttack", false);    // ���� �ִϸ��̼� ����
            agent.isStopped = false;                // ���� ����

            // ���� �۾�
            agent.destination = playerTr.position;  // �÷��̾� ��ġ���� �̵�
            animator.SetBool("IsTrace", true);      // �̵� �ִϸ��̼� ���
        }
        // 3. �ƹ��͵� �ν� ���� ���� ���
        else
        {
            agent.isStopped = true;                 // ���� ����
            animator.SetBool("IsAttack", false);    // ���� �ִϸ��̼� ����
            animator.SetBool("IsTrace", false);     // �̵� �ִϸ��̼� ����
        }
    }
    #endregion
}
