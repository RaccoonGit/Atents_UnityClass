using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("BattleFieldScene");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR // ����Ƽ���� �������� ���ø����̼� ����
        UnityEditor.EditorApplication.isPlaying = false;

#else   // ������ ���� ����
        Application.Quit(); // ������ ���� ����
#endif
    }
}