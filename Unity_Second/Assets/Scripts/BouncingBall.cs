using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingBall : MonoBehaviour
{
    Rigidbody _rigid = null;
    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 pos = new Vector3(Random.Range(-20, 20), Random.Range(5, 15), Random.Range(-20, 20));
            _rigid.AddForce(pos, ForceMode.Impulse);
        }
    }
}
