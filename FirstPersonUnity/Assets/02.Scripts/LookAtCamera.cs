using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private RectTransform canvasTr;
    private Transform mainCameraTr;

    void Start()
    {
        canvasTr = GetComponent<RectTransform>();
        mainCameraTr = Camera.main.transform;
    }

    void Update()
    {
        Vector3 dir = canvasTr.position - mainCameraTr.position;
        canvasTr.rotation = Quaternion.LookRotation(new Vector3(dir.x, 0.0f, dir.z));
    }
}
