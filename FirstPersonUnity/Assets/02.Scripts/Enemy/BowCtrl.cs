using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowCtrl : MonoBehaviour
{
    // #. ����
    // 1. �Ѿ� �߻� �ִϸ��̼�
    // 2. �߻�ü
    // 3. ���콺 ���� Ŭ�� �Ѿ� �߻�
    #region this.Components
    public AudioSource source;              // this.AudioSource ������Ʈ
    #endregion

    #region Public Property
    public AudioClip fireSound;             // �� �߻� Sound Clip
    public AudioClip reloadSound;           // ������ Sound Clip

    public Transform firePos;               // �Ѿ� �߻� ��ġ

    public GameObject arrow;               // �Ѿ� ���� ������Ʈ
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
        // ������Ʈ ���� �Լ� ������ ���� �Լ�
        Instantiate(arrow, firePos.position, firePos.rotation) ;
    }

    public void Reload()
    {
        source.PlayOneShot(reloadSound, 1.0f);
    }
    #endregion
}
