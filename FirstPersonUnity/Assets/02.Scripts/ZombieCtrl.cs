using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// 1. 컴포넌트 초기화
// 2. 플레이어 위치와 자신(좀비)의 위치를 알아야한다
// 3. 추적 범위와 공격 범위에 따라 행동한다.
public class ZombieCtrl : MonoBehaviour
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
    public Transform ZombieTr;          // 내 위치

    public float TraceDist = 20.0f;     // 추적 범위
    public float attackDist = 3.0f;     // 공격 범위
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
        // 플레이어와 자신의 거리 값 계산 메서드
        float dist = Vector3.Distance(playerTr.position, ZombieTr.position);

        // 1. 공격 범위 안에 들어 왔다면
        if(dist<=attackDist)
        {
            // 선행 작업
            animator.SetBool("IsTrace", false);     // 이동 애니메이션 중지
            agent.isStopped = true;                 // 추적 중지

            // 후행 작업
            animator.SetBool("IsAttack", true);     // 공격 애니메이션 재생
        }
        // 2, 추적 범위 안에 들어 왔다면
        else if(dist <= TraceDist)
        {
            // 선행 작업
            animator.SetBool("IsAttack", false);    // 공격 애니메이션 중지
            agent.isStopped = false;                // 추적 시작

            // 후행 작업
            agent.destination = playerTr.position;  // 플레이어 위치까지 이동
            animator.SetBool("IsTrace", true);      // 이동 애니메이션 재생
        }
        // 3. 아무것도 인식 되지 않은 경우
        else
        {
            agent.isStopped = true;                 // 추적 중지
            animator.SetBool("IsAttack", false);    // 공격 애니메이션 중지
            animator.SetBool("IsTrace", false);     // 이동 애니메이션 중지
        }
    }
    #endregion
}
