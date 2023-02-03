using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCtrl : MonoBehaviour
{
    // Private : ���� ���� ������, �ܺ� ���� �Ұ�
    // Horizontal
    private float h;
    // Vertical
    private float v;
    // Rotate
    private float r;

    // �����̴� ���� ����
    private Vector3 moveDir = Vector3.zero;

    // �̵� �ӵ�
    private float moveSpeed = 5.0f;
    // ���콺 ���� X ����Ƽ��
    public float xSensitivity = 100.0f;
    // ���콺 ���� Y ����Ƽ��
    public float ySensitivity = 100.0f;

    public float yMinLimit = -45.0f;
    public float yMaxLimit = 60.0f;
    public float xMinLimit = -360.0f;
    public float xMaxLimit = 360.0f;

    private float yRot = 0.0f;
    private float xRot = 0.0f;

    public Transform myCamera;

    // ���� ����
    private float jumpPower = 5.0f;

    // ���� ���� üũ Bool Ÿ�� ����
    private bool isJump = false;

    public Rigidbody rbody;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
            isJump = true;
        }

        MouseRotation();
    }

    private void FixedUpdate()
    {
        FastRun();
        KeyboardMove();
    }

    private void FastRun()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            moveSpeed = 10.0f;
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = 5.0f;
        }
    }

    // �ݹ� �Լ�
    private void OnCollisionEnter(Collision collision)
    {
        isJump = false;
    }

    private void MouseRotation()
    {
        //r = Input.GetAxis("Mouse X"); // ���콺�� �¿�� �����δٸ�
        //transform.Rotate(Vector3.up * r * Time.deltaTime * mouseSensitivity);

        xRot += Input.GetAxis("Mouse X") * xSensitivity * Time.deltaTime;
        yRot += Input.GetAxis("Mouse Y") * ySensitivity * Time.deltaTime;
        //xRot = Mathf.Clamp(xRot, xMinLimit, xMaxLimit);
        // ���� Ŭ�������� �����ϴ� �Լ� Clamp
        // ���콺 Y�� ���Ʒ��� ������� ĳ���� x������ ȸ��
        // Quaternion() ����� �޼��� 4���� ���Ҽ�
        yRot = Mathf.Clamp(yRot, yMinLimit, yMaxLimit);

        transform.localEulerAngles = new Vector3(-yRot, xRot, 0.0f);


    }

        private void KeyboardMove()
    {
        // A : -1, D : +1
        h = Input.GetAxis("Horizontal");
        // W : +1, S : -1
        v = Input.GetAxis("Vertical");

        moveDir = Vector3.right * h + Vector3.forward * v;

        //transform.Translate(Vector3.right * h * Time.deltaTime * speed);
        //transform.Translate(Vector3.forward * v * Time.deltaTime * speed);

        // ��ǥ �̵� �Լ� (�޼���)
        // normalized ����ȭ w, d Ȥ�� w, a �ΰ��� Ű�� ������ ������ 1�� �ƴ϶� 1.414�� �Ǿ������. normalized�� �ٿ��� 1�� �����.
        transform.Translate(moveDir.normalized * Time.deltaTime * moveSpeed, Space.Self);
    }

    private void Jump()
    {
        // isJump == ture �� ���� �ǹ�
        if (isJump) return;

        rbody.velocity = Vector3.up * jumpPower;
    }
}
