using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    // #. 필요
    // 1. 파티클(이펙트)
    // 2. 사운드
    // 3. 충돌 감지 함수

    #region Public Property
    public GameObject effect;
    public AudioSource _source;
    public AudioClip _clip;
    public string BulletTag = "Bullet";
    #endregion

    /***********************************************************************
    *                            Trigger Events
    ***********************************************************************/
    #region Trigger Events
    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == BulletTag)
        {
            Destroy(col.gameObject);
            GameObject eff = Instantiate(effect,col.transform.position, Quaternion.identity);
            Destroy(eff, 1.0f);
            _source.PlayOneShot(_clip);
        }
    }
    #endregion
}
