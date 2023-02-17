using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MariaCtrl : MonoBehaviour
{
    // #. 필요
    // 1. 애니메이터 컴포넌트
    // 2. NavMeshgAgent 컴포넌트

    #region this.Components
    public Animator animator;           // this.Animator
    public NavMeshAgent agent;          // this.NavMeshAgent
    #endregion

    #region Public Property
    public Transform playerTr;          // 플레이어 위치
    public Transform MariaTr;          // 내 위치

    public float traceDist = 25.0f;     // 추적 범위
    public float attackDist = 5.0f;     // 공격 범위

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
        // 공격 추적에 따른 애니메이션 동작 구현
        // 플레이어와 자신의 거리 값 계산 메서드
        float dist = Vector3.Distance(playerTr.position, transform.position);

        // 1. 공격 범위 안에 들어 왔다면
        if (dist <= attackDist)
        {
            AttackMove();
        }
        // 2, 추적 범위 안에 들어 왔다면
        else if (dist <= traceDist)
        {
            TraceMove();
        }
        // 3. 아무것도 인식 되지 않은 경우
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
        agent.isStopped = true;                 // 추적 중지
        animator.SetBool("IsAttack", false);    // 공격 애니메이션 중지
        animator.SetBool("IsTrace", false);     // 이동 애니메이션 중지
    }

    private void TraceMove()
    {
        // 선행 작업
        animator.SetBool("IsAttack", false);    // 공격 애니메이션 중지
        agent.isStopped = false;                // 추적 시작

        // 후행 작업
        agent.destination = playerTr.position;  // 플레이어 위치까지 이동
        animator.SetBool("IsTrace", true);      // 이동 애니메이션 재생
    }

    private void AttackMove()
    {
        // 선행 작업
        animator.SetBool("IsTrace", false);     // 이동 애니메이션 중지
        agent.isStopped = true;                 // 추적 중지

        // 후행 작업
        animator.SetBool("IsAttack", true);     // 공격 애니메이션 재생
    }
    #endregion
}
