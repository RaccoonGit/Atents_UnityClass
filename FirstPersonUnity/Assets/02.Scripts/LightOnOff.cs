using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOnOff : MonoBehaviour
{
    public Light _light;
    public AudioSource _audioSource;

    public AudioClip OnClip;
    public AudioClip OffClip;

    void Start()
    {
        _light.GetComponent<Light>();
        _audioSource.GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    // other : 충돌체 매게변수
    private void OnTriggerEnter(Collider other)
    {
        // 충돌체의 태그가 Player와 같다면
        if(other.gameObject.tag == "Player")
        {
            // 라이트가 켜진다
            _light.enabled = true;
            _audioSource.PlayOneShot(OnClip, 1.0f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _light.enabled = false;
            _audioSource.PlayOneShot(OffClip, 1.0f);
        }
    }
}
