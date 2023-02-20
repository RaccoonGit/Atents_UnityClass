using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour
{
    #region this.Components
    public Rigidbody rbody;             // this.Rigidbody
    #endregion

    #region Private Property
    private float hp = 0.0f;
    private float hpInit = 100.0f;

    private Color redColor = new Color(1.0f, 0.0f, 0.0f, 0.8f);
    #endregion

    #region Public Property
    public string punchTag = "Punch";
    public GameObject bloodEffect;
    public bool isDie = false;

    public Image hpBar;
    public Text hpText;
    public Image bloodScreen;
    #endregion

    /***********************************************************************
    *                             Unity Events
    ***********************************************************************/
    #region Unity Events
    void Start()
    {
        rbody = GetComponent<Rigidbody>();                  // this.RigidBody ������Ʈ ���ε�

        hp = hpInit;                                        // HP �� �ʱ�ȭ
        hpBar.color = new Color(0.0f, 1.0f, 0.0f, 1.0f);    // HP�� ���� ����
        hpText.text = hp + " / " + hpInit;                  // HP ��ġ ���

        bloodScreen.color = redColor;                       // BloodScreen ���� �� �ʱ�ȭ
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
            EnemyDamage(15.0f);
            StartCoroutine(ShowBloodScreen());
        }
    }

    #endregion

    /***********************************************************************
    *                            Private Methods
    ***********************************************************************/
    #region Private Methods
    private void EnemyDamage(float damage)
    {
        hp -= damage;                            // HP ����
        hp = Mathf.Clamp(hp, 0, 100);

        hpBar.fillAmount = hp / hpInit;
        if (hpBar.fillAmount <= 0.3f)
            hpBar.color = Color.red;
        else if (hpBar.fillAmount <= 0.5f)
            hpBar.color = Color.yellow;
        hpText.text = hp + " / " + hpInit;

        if (hp <= 0) Die();                     // HP�� 0�� ��� ��� ó��
    }

    private void Die()
    {
        isDie = true;
        rbody.isKinematic = true;
        SceneManager.LoadScene("EndScene");

    }
    #endregion

    IEnumerator ShowBloodScreen()
    {
        yield return new WaitForSeconds(Random.Range(0.05f, 0.12f));
        bloodScreen.enabled = true;
        bloodScreen.color = new Color(1.0f, 0.0f, 0.0f, Random.Range(0.3f, 0.8f));
        yield return new WaitForSeconds(Random.Range(0.05f, 0.12f));
        bloodScreen.enabled = false;
    }
}
