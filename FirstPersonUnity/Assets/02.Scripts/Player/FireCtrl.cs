using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour
{
    // #. ����
    // 1. �Ѿ� �߻� �ִϸ��̼�
    // 2. �߻�ü
    // 3. ���콺 ���� Ŭ�� �Ѿ� �߻�

    #region this.Components
    public Animation combatSG;              // this.Animation ������Ʈ
    public AudioSource source;              // this.AudioSource ������Ʈ
    #endregion

    #region Public Property
    public AudioClip fireSound;             // �� �߻� Sound Clip
    public AudioClip reloadSound;           // ������ Sound Clip

    public ParticleSystem muzzleFlash;      // �� �߻� Effect
    public ParticleSystem cartridgeEject;   // ź�� ���� Effect

    public HandAnimation handAnim;          // HandAnimation Class

    public Transform firePos;               // �Ѿ� �߻� ��ġ

    public GameObject bullet;               // �Ѿ� ���� ������Ʈ

    public static int bulletCount = 0;      // �Ѿ� ��
    public static bool isFire = false;      // �߻������� ���¸� üũ�ϴ� Bool
    public static bool isEmpty = false;     // ������������ ���¸� üũ�ϴ� Bool
    #endregion

    /***********************************************************************
    *                             Unity Event
    ***********************************************************************/
    #region Unity Event
    void Start()
    {
        combatSG = GameObject.Find("CombatSG_Player").GetComponent<Animation>();
        source = GetComponent<AudioSource>();
        handAnim = GetComponentInChildren<HandAnimation>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !handAnim.isRunning && !handAnim.isReloading)
        {
            StartCoroutine(FastBullet(5));
        }
    }
    #endregion

    /***********************************************************************
    *                            Private Methods
    ***********************************************************************/
    #region Private Methods
    void Fire(float x = 0.0f, float y = 0.0f)
    {
        combatSG.Play("fire");
        muzzleFlash.Play();
        cartridgeEject.Play();
        source.PlayOneShot(fireSound, 1.0f);
        bulletCount++;
        // ������Ʈ ���� �Լ� ������ ���� �Լ�
        Instantiate(bullet, firePos.position, firePos.rotation * Quaternion.Euler(new Vector3(x, y, 0.0f)));
    }
    #endregion

    /***********************************************************************
    *                              Coroutines
    ***********************************************************************/
    #region Coroutines
    IEnumerator FastBullet(int shellCount)
    {
        Fire();
        for (int i = 0; i < shellCount-1; i++)
        {
            float x = Random.Range(-0.5f, 0.5f);
            float y = Random.Range(-0.5f, 0.5f);
            Fire(x, y);
        }
        yield return null;
    }
    #endregion
}
