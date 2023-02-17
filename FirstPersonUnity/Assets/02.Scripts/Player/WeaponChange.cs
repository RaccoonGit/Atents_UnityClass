using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChange : MonoBehaviour
{
    // #. ����
    // 1. Ű���忡�� 1��, 2��, 3�� �ѱⱳü
    // 2. �޽� ������ �迭 �����ؼ� ���� �� ���� Ȱ��ȭ/��Ȱ��ȭ

    #region Public Property
    public Animation anim;
    #endregion

    #region Public Property
    public GameObject _ak47;                // MeshRenderer ������Ʈ�� ã�� ���� ���� ������Ʈ
    public GameObject _m4a1;                // MeshRenderer ������Ʈ�� ã�� ���� ���� ������Ʈ

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

        // ����
        for (int i = 0; i < m4a1.Length; i++)
        {
            m4a1[i].enabled = true;
        }
        // ����
        spas12.enabled = false;
        for (int i = 0; i < ak47.Length; i++)
        {
            ak47[i].enabled = false;
        }
    }

    private void KeyTwo()
    {
        anim.Play("draw");

        // ����
        for (int i = 0; i < ak47.Length; i++)
        {
            ak47[i].enabled = true;
        }

        // ����
        spas12.enabled = false;
        for (int i = 0; i < m4a1.Length; i++)
        {
            m4a1[i].enabled = false;
        }
    }

    private void KeyOne()
    {
        anim.Play("draw");

        // ����
        spas12.enabled = true;

        // ����
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
