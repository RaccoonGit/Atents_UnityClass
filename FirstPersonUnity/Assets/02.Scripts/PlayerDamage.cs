using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour
{
    #region this.Components
    public Rigidbody rbody;             // this.Rigidbody
    #endregion

    #region Private Property
    private float hp = 0.0f;
    private float hpInit = 100.0f;

    #endregion

    #region Public Property
    public string punchTag = "Punch";
    public GameObject bloodEffect;
    public bool isDie = false;

    public Image hpBar;
    public Text hpText;
    #endregion

    /***********************************************************************
    *                             Unity Events
    ***********************************************************************/
    #region Unity Events
    void Start()
    {
        rbody = GetComponent<Rigidbody>();

        hp = hpInit;
        hpBar.color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
        hpText.text = hp + " / " + hpInit;
    }
    #endregion

    /***********************************************************************
    *                           Collision Events
    ***********************************************************************/
    #region Collision Events
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == punchTag)
        {
            hp -= 10.0f;                            // HP 감소
            hp = Mathf.Clamp(hp, 0, 100);

            hpBar.fillAmount = hp / hpInit;
            if (hpBar.fillAmount <= 0.3f)
                hpBar.color = Color.red;
            else if (hpBar.fillAmount <= 0.5f)
                hpBar.color = Color.yellow;
            hpText.text = hp + " / " + hpInit;

            if (hp <= 0) Die();                     // HP가 0인 경우 사망 처리
        }
    }

    #endregion

    /***********************************************************************
    *                            Private Methods
    ***********************************************************************/
    #region Private Methods
    private void Die()
    {
        isDie = true;
        rbody.isKinematic = true;
    }
    #endregion
}
