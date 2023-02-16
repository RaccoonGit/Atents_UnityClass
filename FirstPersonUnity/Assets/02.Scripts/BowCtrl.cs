using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowCtrl : MonoBehaviour
{
    // #. 구성
    // 1. 총알 발사 애니메이션
    // 2. 발사체
    // 3. 마우스 왼쪽 클릭 총알 발사
    #region this.Components
    public AudioSource source;              // this.AudioSource 컴포넌트
    #endregion

    #region Public Property
    public AudioClip fireSound;             // 총 발사 Sound Clip
    public AudioClip reloadSound;           // 재장전 Sound Clip

    public Transform firePos;               // 총알 발사 위치

    public GameObject arrow;               // 총알 게임 오브젝트
    #endregion

    /***********************************************************************
    *                             Unity Event
    ***********************************************************************/
    #region Unity Event
    void Start()
    {
        source = GetComponent<AudioSource>();
    }
    #endregion

    /***********************************************************************
    *                            Public Methods
    ***********************************************************************/
    #region Public Methods
    public void Fire()
    {
        source.PlayOneShot(fireSound, 1.0f);
        // 오브젝트 생성 함수 프리팹 생성 함수
        Instantiate(arrow, firePos.position, firePos.rotation) ;
    }

    public void Reload()
    {
        source.PlayOneShot(reloadSound, 1.0f);
    }
    #endregion
}
