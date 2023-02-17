using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOnOff : MonoBehaviour
{
    #region this.Components
    public Light _light;                // this.Light 컴포넌트
    public AudioSource _audioSource;    // this.Audiosource 컴포넌트
    #endregion

    #region Public Property
    public AudioClip OnClip;            // Light On 시 재생될 Audio Clip
    public AudioClip OffClip;           // Light Off 시 재생될 Audio Clip
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
    // other : 충돌체 매게변수
    private void OnTriggerEnter(Collider other)
    {
        // 충돌체의 태그가 Player와 같다면
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Zombie" || other.gameObject.tag == "Skeleton" || other.gameObject.tag == "Monster")
        {
            // 라이트가 켜진다
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
