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
    public Transform playerTr;          // �÷��̾� ��ġ
    public Transform MonsterTr;          // �� ��ġ

    public float TraceDist = 20.0f;     // ���� ����
    public float attackDist = 2.5f;     // ���� ����

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

        // ������ ���� ����
        if(ranIndex == 5)
        {
            StartCoroutine(ChangeColor());
        }
        // ���� ���� ����
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

        // �÷��̾�� �ڽ��� �Ÿ� �� ��� �޼���
        float dist = Vector3.Distance(playerTr.position, MonsterTr.position);

        // 1. ���� ���� �ȿ� ��� �Դٸ�
        if (dist <= attackDist)
        {
            // ���� �۾�
            animator.SetBool("IsTrace", false);     // �̵� �ִϸ��̼� ����
            agent.isStopped = true;                 // ���� ����

            // ���� �۾�
            if (attackRanRoutine != null) return;
            attackRanRoutine = StartCoroutine(AttackRandom(2.0f));
        }
        // 2, ���� ���� �ȿ� ��� �Դٸ�
        else if (dist <= TraceDist)
        {
            // ���� �۾�
            animator.SetBool("IsAttack1", false);     // ���� �ִϸ��̼� ����
            animator.SetBool("IsAttack2", false);     // ���� �ִϸ��̼� ����
            agent.isStopped = false;                // ���� ����

            // ���� �۾�
            agent.destination = playerTr.position;  // �÷��̾� ��ġ���� �̵�
            animator.SetBool("IsTrace", true);      // �̵� �ִϸ��̼� ���
        }
        // 3. �ƹ��͵� �ν� ���� ���� ���
        else
        {
            agent.isStopped = true;                 // ���� ����
            animator.SetBool("IsAttack1", false);     // ���� �ִϸ��̼� ����
            animator.SetBool("IsAttack2", false);     // ���� �ִϸ��̼� ����
            animator.SetBool("IsTrace", false);     // �̵� �ִϸ��̼� ����
        }
    }
    #endregion

    private IEnumerator AttackRandom(float time)
    {
        float timer = 0.0f;

        int ran = Random.Range(0, 2);
        if (ran == 1)
        {
            animator.SetBool("IsAttack1", true);     // ���� �ִϸ��̼� ���
        }
        else
        {
            animator.SetBool("IsAttack2", true);     // ���� �ִϸ��̼� ���
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
