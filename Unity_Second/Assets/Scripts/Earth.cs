using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour
{
    public float Speed = 50.0f;

    // C, C++ : Function 펑션 C# : Method 메서드
    // 게임 시작 전 한번만 호출 되는 공간
    void Start()
    {
        
    }

    // 컴퓨터 프레임당 한번씩 계속 호출
    void Update()
    {
        // Time.deltaTime : 낮은 사양의 디바이스와 높은 사양의 디바이스의 게임에 맞는 부드러운 프레임으로 만들어준다.
        transform.Rotate(0.0f, -1.5f * Time.deltaTime * Speed, 0.0f);
        Debug.DrawRay(transform.position, transform.up * 20.0f, Color.green);
        Debug.DrawRay(transform.position, -transform.up * 20.0f, Color.green);
        Debug.DrawRay(transform.position, Vector3.up * 20.0f, Color.white);
        Debug.DrawRay(transform.position, Vector3.down * 20.0f, Color.white);
    }
}
