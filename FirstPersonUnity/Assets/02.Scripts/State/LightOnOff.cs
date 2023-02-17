using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOnOff : MonoBehaviour
{
    #region this.Components
    public Light _light;                // this.Light ������Ʈ
    public AudioSource _audioSource;    // this.Audiosource ������Ʈ
    #endregion

    #region Public Property
    public AudioClip OnClip;            // Light On �� ����� Audio Clip
    public AudioClip OffClip;           // Light Off �� ����� Audio Clip
    #endregion

    /***********************************************************************
    *                             Unity Events
    ***********************************************************************/
    #region Unity Events
    void Start()
    {
        _light.GetComponent<Light>();
        _audioSource.GetComponent<AudioSource>();
    }
    #endregion

    /***********************************************************************
    *                            Trigger Events
    ***********************************************************************/
    #region Trigger Events
    // other : �浹ü �ŰԺ���
    private void OnTriggerEnter(Collider other)
    {
        // �浹ü�� �±װ� Player�� ���ٸ�
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Zombie" || other.gameObject.tag == "Skeleton" || other.gameObject.tag == "Monster")
        {
            // ����Ʈ�� ������
            _light.enabled = true;
            _audioSource.PlayOneShot(OnClip, 1.0f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Zombie" || other.gameObject.tag == "Skeleton" || other.gameObject.tag == "Monster")
        {
            _light.enabled = false;
            _audioSource.PlayOneShot(OffClip, 1.0f);
        }
    }
    #endregion
}
