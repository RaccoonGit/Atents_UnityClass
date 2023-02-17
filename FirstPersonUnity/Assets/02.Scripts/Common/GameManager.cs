using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // 1. 적 프리펩
    // 2. 몇초 간격으로 나타날지
    // 3. 스폰 포인트

    #region Private Property
    private float zombieCreateTime = 3.0f;        // 3초 간격으로 태어나기
    private float skeletonCreateTime = 5.0f;        // 3초 간격으로 태어나기
    private float monsterCreateTime = 10.0f;        // 3초 간격으로 태어나기
    private float zombieTimePrev;
    private float skeletonTimePrev;
    private float monsterTimePrev;
    private int zombieMaxCount = 15;
    private int skeletonMaxCount = 10;
    private int monsterMaxCount = 5;
    #endregion

    #region Public Property
    public GameObject zombiePrefab;         // 적 프리펩
    public GameObject skeletonPrefab;         // 적 프리펩
    public GameObject monsterPrefab;         // 적 프리펩
    public Transform[] SpawnPoints;   // 태어날 위치

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
    // Start() 함수보다 먼저 호출
    private void Awake()
    {
        gameManager = this;
    }

    void Start()
    {
        // 하이라키 SpawnPoints 오브젝트를 찾고 그 하위 자식 오브젝트들의 트랜스폼을 Points 배열에 담는다.
        // 부모 오브젝트 부터 하위 오브젝트 트렌스폼까지
        SpawnPoints = GameObject.Find("SpawnPoint").GetComponentsInChildren<Transform>();

        // 현재 시간을 대입한다.
        zombieTimePrev = Time.time;
        skeletonTimePrev = Time.time;
        monsterTimePrev = Time.time;
    }

    void Update()
    {
        // Time.time - timePrev = 흘러간 시간
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
