using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAnimation : MonoBehaviour
{
    #region this.Components
    public Animation combatSG;          // this.Animation 컴포넌트
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

        // static 붙힌 변수는 클래스명.변수명 으로 호출 가능
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
        // 직전의 동작과 지금 하려는 동작을 0.3초동안 혼합해서 부드러운 애니메이션을 만들어준다.
        combatSG.CrossFade("pump1", 0.3f);

        yield return new WaitForSeconds(0.5f);
        FireCtrl.bulletCount = 0;
        isReloading = false;
    }
    #endregion
}