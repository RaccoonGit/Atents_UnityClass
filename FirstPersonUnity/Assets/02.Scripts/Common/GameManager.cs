using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // 1. �� ������
    // 2. ���� �������� ��Ÿ����
    // 3. ���� ����Ʈ

    #region Private Property
    private float zombieCreateTime = 3.0f;        // 3�� �������� �¾��
    private float skeletonCreateTime = 5.0f;        // 3�� �������� �¾��
    private float monsterCreateTime = 10.0f;        // 3�� �������� �¾��
    private float zombieTimePrev;
    private float skeletonTimePrev;
    private float monsterTimePrev;
    private int zombieMaxCount = 15;
    private int skeletonMaxCount = 10;
    private int monsterMaxCount = 5;
    #endregion

    #region Public Property
    public GameObject zombiePrefab;         // �� ������
    public GameObject skeletonPrefab;         // �� ������
    public GameObject monsterPrefab;         // �� ������
    public Transform[] SpawnPoints;   // �¾ ��ġ

    public Text zombieKillCnt;
    public Text skeletonKillCnt;
    public Text monsterKillCnt;
    public int total1 = 0;
    public int total2 = 0;
    public int total3 = 0;

    public static GameManager gameManager;
    #endregion

    /***********************************************************************
    *                             Unity Events
    ***********************************************************************/
    #region Unity Events
    // Start() �Լ����� ���� ȣ��
    private void Awake()
    {
        gameManager = this;
    }

    void Start()
    {
        // ���̶�Ű SpawnPoints ������Ʈ�� ã�� �� ���� �ڽ� ������Ʈ���� Ʈ�������� Points �迭�� ��´�.
        // �θ� ������Ʈ ���� ���� ������Ʈ Ʈ����������
        SpawnPoints = GameObject.Find("SpawnPoint").GetComponentsInChildren<Transform>();

        // ���� �ð��� �����Ѵ�.
        zombieTimePrev = Time.time;
        skeletonTimePrev = Time.time;
        monsterTimePrev = Time.time;
    }

    void Update()
    {
        // Time.time - timePrev = �귯�� �ð�
        if(Time.time - zombieTimePrev > zombieCreateTime)
        {
            int zombieCount = (int) GameObject.FindGameObjectsWithTag("Zombie").Length;
            if(zombieCount < zombieMaxCount)
            {
                CreateMonster(zombiePrefab);
            }
            zombieTimePrev = Time.time;
        }

        if (Time.time - skeletonTimePrev > skeletonCreateTime)
        {
            int skeletonCount = (int)GameObject.FindGameObjectsWithTag("Skeleton").Length;
            if (skeletonCount < skeletonMaxCount)
            {
                CreateMonster(skeletonPrefab);
            }
            skeletonTimePrev = Time.time;
        }

        if (Time.time - monsterTimePrev > monsterCreateTime)
        {
            int monsterCount = (int)GameObject.FindGameObjectsWithTag("Monster").Length;
            if (monsterCount < monsterMaxCount)
            {
                CreateMonster(monsterPrefab);
            }
            monsterTimePrev = Time.time;
        }
    }
    #endregion

    /***********************************************************************
    *                            Private Methods
    ***********************************************************************/
    #region Private Methods
    private void CreateMonster(GameObject monster)
    {
        int idx = Random.Range(1, SpawnPoints.Length);
        Instantiate(monster, SpawnPoints[idx].position, SpawnPoints[idx].rotation);
    }

    private void CreateZombie()
    {
        int idx = Random.Range(1, SpawnPoints.Length);
        Instantiate(zombiePrefab, SpawnPoints[idx].position, SpawnPoints[idx].rotation);
    }
    public void MonsterScore(int score)
    {
        total3 += score;
        monsterKillCnt.text = "Monster Kill: " + "<color=#ff0000>" + total3.ToString() + "</color>";
    }

    public void SkeletonScore(int score)
    {
        total2 += score;
        skeletonKillCnt.text = "Skeleton Kill: " + "<color=#ff0000>" + total2.ToString() + "</color>";
    }

    public void ZombieScore(int score)
    {
        total1 += score;
        zombieKillCnt.text = "Zombie Kill: " + "<color=#ff0000>" + total1.ToString() + "</color>";
    }
    #endregion
}
