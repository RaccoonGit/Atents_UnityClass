using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChange : MonoBehaviour
{
    // #. 구성
    // 1. 키보드에서 1번, 2번, 3번 총기교체
    // 2. 메쉬 렌더러 배열 선언해서 저장 한 다음 활성화/비활성화

    #region Public Property
    public Animation anim;
    #endregion

    #region Public Property
    public GameObject _ak47;                // MeshRenderer 컴포넌트를 찾기 위한 게임 오브젝트
    public GameObject _m4a1;                // MeshRenderer 컴포넌트를 찾기 위한 게임 오브젝트

    public SkinnedMeshRenderer spas12;
    public MeshRenderer[] ak47;
    public MeshRenderer[] m4a1;
    #endregion


    /***********************************************************************
    *                             Unity Events
    ***********************************************************************/
    #region Unity Events
    void Start()
    {
        ak47 = _ak47.GetComponentsInChildren<MeshRenderer>();
        m4a1 = _m4a1.GetComponentsInChildren<MeshRenderer>();
        anim = GetComponent<Animation>();
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            KeyOne();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            KeyTwo();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            KeyThree();
        }
    }
    #endregion

    /***********************************************************************
    *                            Private Methods
    ***********************************************************************/
    #region Private Methods
    private void KeyThree()
    {
        anim.Play("draw");

        // 장착
        for (int i = 0; i < m4a1.Length; i++)
        {
            m4a1[i].enabled = true;
        }
        // 해제
        spas12.enabled = false;
        for (int i = 0; i < ak47.Length; i++)
        {
            ak47[i].enabled = false;
        }
    }

    private void KeyTwo()
    {
        anim.Play("draw");

        // 장착
        for (int i = 0; i < ak47.Length; i++)
        {
            ak47[i].enabled = true;
        }

        // 해제
        spas12.enabled = false;
        for (int i = 0; i < m4a1.Length; i++)
        {
            m4a1[i].enabled = false;
        }
    }

    private void KeyOne()
    {
        anim.Play("draw");

        // 장착
        spas12.enabled = true;

        // 해제
        for (int i = 0; i < ak47.Length; i++)
        {
            ak47[i].enabled = false;
        }
        for (int i = 0; i < m4a1.Length; i++)
        {
            m4a1[i].enabled = false;
        }
    }
    #endregion
}
