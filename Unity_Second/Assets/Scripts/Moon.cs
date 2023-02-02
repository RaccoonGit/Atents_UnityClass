using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public float Speed = 50.0f;
    public Transform moon = null;

    // 게임 시작 전 한번만 호출 되는 공간
    void Start()
    {
        
    }

    // 컴퓨터 프레임당 한번씩 계속 호출
    void Update()
    {
        transform.Rotate(0.0f, -2.5f * Time.deltaTime * Speed, 0.0f);
        moon.transform.Rotate(0.0f, 2.5f * Time.deltaTime * Speed, 0.0f);
        Debug.DrawRay(moon.position, moon.up * 10.0f, Color.blue);
        Debug.DrawRay(moon.position, -moon.up * 10.0f, Color.blue);
        Debug.DrawRay(transform.position, transform.up * 20.0f, Color.red);
        Debug.DrawRay(transform.position, -transform.up * 20.0f, Color.red);
    }
}
