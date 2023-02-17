using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAnimation : MonoBehaviour
{
    #region this.Components
    public Animation combatSG;          // this.Animation ������Ʈ
    #endregion

    #region Public Property
    public bool isRunning = false;
    public bool isReloading = false;
    #endregion

    /***********************************************************************
    *                             Unity Events
    ***********************************************************************/
    #region Unity Events
    void Start()
    {
        combatSG = GetComponent<Animation>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            combatSG.Play("running");
            isRunning = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            combatSG.Play("runStop");
            isRunning = false;
        }

        // static ���� ������ Ŭ������.������ ���� ȣ�� ����
        if(FireCtrl.bulletCount == 10)
        {
            StartCoroutine(Reload());
        }
    }
    #endregion

    /***********************************************************************
    *                         Finity State Machine
    ***********************************************************************/
    #region Finity State Machine

    #endregion

    /***********************************************************************
    *                              Coroutines
    ***********************************************************************/
    #region Coroutines
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(0.5f);
        isReloading = true;
        // ������ ���۰� ���� �Ϸ��� ������ 0.3�ʵ��� ȥ���ؼ� �ε巯�� �ִϸ��̼��� ������ش�.
        combatSG.CrossFade("pump1", 0.3f);

        yield return new WaitForSeconds(0.5f);
        FireCtrl.bulletCount = 0;
        isReloading = false;
    }
    #endregion
}