using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour
{
    // #. 구성
    // 1. 총알 발사 애니메이션
    // 2. 발사체
    // 3. 마우스 왼쪽 클릭 총알 발사

    #region this.Components
    public Animation combatSG;              // this.Animation 컴포넌트
    public AudioSource source;              // this.AudioSource 컴포넌트
    #endregion

    #region Public Property
    public AudioClip fireSound;             // 총 발사 Sound Clip
    public AudioClip reloadSound;           // 재장전 Sound Clip

    public ParticleSystem muzzleFlash;      // 총 발사 Effect
    public ParticleSystem cartridgeEject;   // 탄피 배출 Effect

    public HandAnimation handAnim;          // HandAnimation Class

    public Transform firePos;               // 총알 발사 위치

    public GameObject bullet;               // 총알 게임 오브젝트

    public static int bulletCount = 0;      // 총알 수
    public static bool isFire = false;      // 발사중인지 상태를 체크하는 Bool
    public static bool isEmpty = false;     // 재장전중인지 상태를 체크하는 Bool
    #endregion

    /***********************************************************************
    *                             Unity Event
    ***********************************************************************/
    #region Unity Event
    void Start()
    {
        combatSG = GameObject.Find("CombatSG_Player").GetComponent<Animation>();
        source = GetComponent<AudioSource>();
        handAnim = GetComponentInChildren<HandAnimation>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !handAnim.isRunning && !handAnim.isReloading)
        {
            Fire();
        }
    }
    #endregion

    /***********************************************************************
    *                            Private Methods
    ***********************************************************************/
    #region Private Methods
    void Fire()
    {
        combatSG.Play("fire");
        muzzleFlash.Play();
        cartridgeEject.Play();
        source.PlayOneShot(fireSound, 1.0f);
        bulletCount++;
        // 오브젝트 생성 함수 프리팹 생성 함수
        Instantiate(bullet, firePos.position, firePos.rotation);
    }
    #endregion

    /***********************************************************************
    *                              Coroutines
    ***********************************************************************/
    #region Coroutines
    IEnumerator FastBullet()
    {
        Fire();
        yield return new WaitForSeconds(0.15f);
        Fire();
        yield return new WaitForSeconds(0.15f);
        Fire();
    }
    #endregion
}
