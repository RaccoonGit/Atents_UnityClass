using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeletonCtrl : MonoBehaviour
{
    // 1. 컴포넌트 초기화
    // 2. 플레이어랑 스켈레톤 위치
    // 3. 추적 범위 공격 범위 지정

    #region this.Components
    public Animator animator;           // this.Animator
    public NavMeshAgent agent;          // this.NavMeshAgent
    #endregion

    #region Public Property
    public Transform skeletonTr;
    public Transform playerTr;
    public float traceDist = 20.0f;
    public float attackDist = 3.5f;

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
    }

    // Update is called once per frame
    void Update()
    {
        if (skeleDmg.isDie == true) return;
        // 공격 추적에 따른 애니메이션 동작 구현
        // 플레이어와 자신의 거리 값 계산 메서드
        float dist = Vector3.Distance(playerTr.position, skeletonTr.position);

        // 1. 공격 범위 안에 들어 왔다면
        if (dist <= attackDist)
        {
            // 선행 작업
            animator.SetBool("IsTrace", false);     // 이동 애니메이션 중지
            agent.isStopped = true;                 // 추적 중지

            // 후행 작업
            animator.SetBool("IsAttack", true);     // 공격 애니메이션 재생
        }
        // 2, 추적 범위 안에 들어 왔다면
        else if (dist <= traceDist)
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

    /***********************************************************************
    *                            Private Methods
    ***********************************************************************/
    #region Private Methods
    #endregion
}
