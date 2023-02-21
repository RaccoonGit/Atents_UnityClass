using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndUI : MonoBehaviour
{

    void Start()
    {
        // 마우스 커서를 보이게 안보이게
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
