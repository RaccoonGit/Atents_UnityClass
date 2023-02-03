using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCtrl : MonoBehaviour
{
    // Private : 접근 제어 지시자, 외부 접근 불가
    // Horizontal
    private float h;
    // Vertical
    private float v;
    // Rotate
    private float r;

    // 움직이는 방향 벡터
    private Vector3 moveDir = Vector3.zero;

    // 이동 속도
    private float moveSpeed = 5.0f;
    // 마우스 감지 X 센스티브
    public float xSensitivity = 100.0f;
    // 마우스 감지 Y 센스티브
    public float ySensitivity = 100.0f;

    public float yMinLimit = -45.0f;
    public float yMaxLimit = 60.0f;
    public float xMinLimit = -360.0f;
    public float xMaxLimit = 360.0f;

    private float yRot = 0.0f;
    private float xRot = 0.0f;

    public Transform myCamera;

    // 점프 높이
    private float jumpPower = 5.0f;

    // 점프 가능 체크 Bool 타입 변수
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

    // 콜백 함수
    private void OnCollisionEnter(Collision collision)
    {
        isJump = false;
    }

    private void MouseRotation()
    {
        //r = Input.GetAxis("Mouse X"); // 마우스를 좌우로 움직인다면
        //transform.Rotate(Vector3.up * r * Time.deltaTime * mouseSensitivity);

        xRot += Input.GetAxis("Mouse X") * xSensitivity * Time.deltaTime;
        yRot += Input.GetAxis("Mouse Y") * ySensitivity * Time.deltaTime;
        //xRot = Mathf.Clamp(xRot, xMinLimit, xMaxLimit);
        // 수학 클래스에서 제한하는 함수 Clamp
        // 마우스 Y가 위아래로 움지깅면 캐릭터 x축으로 회전
        // Quaternion() 사원수 메서드 4차원 복소수
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

        // 좌표 이동 함수 (메서드)
        // normalized 정규화 w, d 혹은 w, a 두개의 키를 누르기 때문에 1이 아니라 1.414가 되어버린다. normalized를 붙여서 1로 만든다.
        transform.Translate(moveDir.normalized * Time.deltaTime * moveSpeed, Space.Self);
    }

    private void Jump()
    {
        // isJump == ture 와 같은 의미
        if (isJump) return;

        rbody.velocity = Vector3.up * jumpPower;
    }
}
