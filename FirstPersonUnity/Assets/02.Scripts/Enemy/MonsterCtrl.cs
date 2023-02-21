using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterCtrl : MonoBehaviour
{
    #region this.Components
    public Animator animator;           // this.Animator
    public NavMeshAgent agent;          // this.NavMeshAgent
    #endregion

    #region Public Property
    public Transform playerTr;          // 플레이어 위치
    public Transform MonsterTr;          // 내 위치

    public float TraceDist = 20.0f;     // 추적 범위
    public float attackDist = 2.5f;     // 공격 범위

    public SkinnedMeshRenderer[] meshRender;
    public Material[] mats;

    public MonsterDamage monsterDmg;
    #endregion

    private Coroutine attackRanRoutine = null;

    /***********************************************************************
    *                             Unity Events
    ***********************************************************************/
    #region Unity Events
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        playerTr = GameObject.FindWithTag("Player").transform;
        MonsterTr = GetComponent<Transform>();
        monsterDmg = GetComponent<MonsterDamage>();

        int ranIndex = Random.Range(0,6);
        Debug.Log(ranIndex);

        // 무지개 색상 몬스터
        if(ranIndex == 5)
        {
            StartCoroutine(ChangeColor());
        }
        // 랜덤 색상 몬스터
        else
        {
            foreach (SkinnedMeshRenderer skmeshRen in meshRender)
            {
                skmeshRen.material = mats[ranIndex];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (monsterDmg.isDie == true || playerTr.GetComponent<PlayerDamage>().isDie) return;

        // 플레이어와 자신의 거리 값 계산 메서드
        float dist = Vector3.Distance(playerTr.position, MonsterTr.position);

        // 1. 공격 범위 안에 들어 왔다면
        if (dist <= attackDist)
        {
            // 선행 작업
            animator.SetBool("IsTrace", false);     // 이동 애니메이션 중지
            agent.isStopped = true;                 // 추적 중지

            // 후행 작업
            if (attackRanRoutine != null) return;
            attackRanRoutine = StartCoroutine(AttackRandom(2.0f));
        }
        // 2, 추적 범위 안에 들어 왔다면
        else if (dist <= TraceDist)
        {
            // 선행 작업
            animator.SetBool("IsAttack1", false);     // 공격 애니메이션 중지
            animator.SetBool("IsAttack2", false);     // 공격 애니메이션 중지
            agent.isStopped = false;                // 추적 시작

            // 후행 작업
            agent.destination = playerTr.position;  // 플레이어 위치까지 이동
            animator.SetBool("IsTrace", true);      // 이동 애니메이션 재생
        }
        // 3. 아무것도 인식 되지 않은 경우
        else
        {
            agent.isStopped = true;                 // 추적 중지
            animator.SetBool("IsAttack1", false);     // 공격 애니메이션 중지
            animator.SetBool("IsAttack2", false);     // 공격 애니메이션 중지
            animator.SetBool("IsTrace", false);     // 이동 애니메이션 중지
        }
    }
    #endregion

    private IEnumerator AttackRandom(float time)
    {
        float timer = 0.0f;

        int ran = Random.Range(0, 2);
        if (ran == 1)
        {
            animator.SetBool("IsAttack1", true);     // 공격 애니메이션 재생
        }
        else
        {
            animator.SetBool("IsAttack2", true);     // 공격 애니메이션 재생
        }

        while (timer < time)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        attackRanRoutine = null;
    }

    private IEnumerator ChangeColor()
    {
        int index = 0;
        while (true)
        {
            if (index == 5) index = 0;
            foreach (SkinnedMeshRenderer skmeshRen in meshRender)
            {
                skmeshRen.material = mats[index];
                yield return new WaitForSeconds(0.5f);
            }
            index++;
            yield return new WaitForSeconds(1.5f);
        }
    }
}
