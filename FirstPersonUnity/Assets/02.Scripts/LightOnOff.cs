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

    // other : �浹ü �ŰԺ���
    private void OnTriggerEnter(Collider other)
    {
        // �浹ü�� �±װ� Player�� ���ٸ�
        if(other.gameObject.tag == "Player")
        {
            // ����Ʈ�� ������
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
