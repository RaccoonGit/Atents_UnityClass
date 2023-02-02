using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour
{
    public float Speed = 50.0f;

    // C, C++ : Function ��� C# : Method �޼���
    // ���� ���� �� �ѹ��� ȣ�� �Ǵ� ����
    void Start()
    {
        
    }

    // ��ǻ�� �����Ӵ� �ѹ��� ��� ȣ��
    void Update()
    {
        // Time.deltaTime : ���� ����� ����̽��� ���� ����� ����̽��� ���ӿ� �´� �ε巯�� ���������� ������ش�.
        transform.Rotate(0.0f, -1.5f * Time.deltaTime * Speed, 0.0f);
        Debug.DrawRay(transform.position, transform.up * 20.0f, Color.green);
        Debug.DrawRay(transform.position, -transform.up * 20.0f, Color.green);
        Debug.DrawRay(transform.position, Vector3.up * 20.0f, Color.white);
        Debug.DrawRay(transform.position, Vector3.down * 20.0f, Color.white);
    }
}
