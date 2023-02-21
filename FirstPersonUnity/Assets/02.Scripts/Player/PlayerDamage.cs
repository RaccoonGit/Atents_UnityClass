using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
// FirstPersonController에 접근하기 위한 경로명
using UnityStandardAssets.Characters.FirstPerson;

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
    public GameObject ImgInfo;
    #endregion

    /***********************************************************************
    *                             Unity Events
    ***********************************************************************/
    #region Unity Events
    void Start()
    {
        rbody = GetComponent<Rigidbody>();                  // this.RigidBody 컴포넌트 바인딩

        hp = hpInit;                                        // HP 값 초기화
        hpBar.color = new Color(0.0f, 1.0f, 0.0f, 1.0f);    // HP바 색상 지정
        hpText.text = hp + " / " + hpInit;                  // HP 수치 출력

        bloodScreen.color = redColor;                       // BloodScreen 색상 값 초기화
    }
    #endregion

    /***********************************************************************
    *                           Collision Events
    ***********************************************************************/
    #region Collision Events
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == punchTag && !isDie)
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
        hp -= damage;                            // HP 감소
        hp = Mathf.Clamp(hp, 0, 100);

        hpBar.fillAmount = hp / hpInit;
        if (hpBar.fillAmount <= 0.3f)
            hpBar.color = Color.red;
        else if (hpBar.fillAmount <= 0.5f)
            hpBar.color = Color.yellow;
        hpText.text = hp + " / " + hpInit;

        if (hp <= 0)
        {
            isDie = true;
            rbody.isKinematic = true;

            ImgInfo.SetActive(true);
            StartCoroutine(SlowShow(ImgInfo));
            Invoke("Die", 3.0f);
            GetComponent<FirstPersonController>().enabled = false;
            GetComponent<FireCtrl>().enabled = false;
        }
    }

    // HP가 0인 경우 사망 처리
    private void Die()
    {
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

    IEnumerator SlowShow(GameObject imgInfo)
    {
        Image img = imgInfo.GetComponent<Image>();
        Text txt = imgInfo.GetComponentInChildren<Text>();
        float alpha = 0.0f;
        while(alpha < 1.0f)
        {
            alpha += Time.deltaTime;
            img.color = new Color(1.0f, 0.0f, 0.0f, alpha);
            txt.color = new Color(0.0f, 0.0f, 0.0f, alpha);
            yield return null;
        }
    }

}
