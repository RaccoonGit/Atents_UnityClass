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
#if UNITY_EDITOR // 유니티에서 실행중인 어플리케이션 종료
        UnityEditor.EditorApplication.isPlaying = false;

#else   // 빌드한 게임 종료
        Application.Quit(); // 빌드한 게임 종료
#endif
    }
}