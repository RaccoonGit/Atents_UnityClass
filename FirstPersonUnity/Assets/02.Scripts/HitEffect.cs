using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    // #. �ʿ�
    // 1. ��ƼŬ(����Ʈ)
    // 2. ����
    // 3. �浹 ���� �Լ�

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
