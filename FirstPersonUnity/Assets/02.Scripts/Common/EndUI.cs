using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndUI : MonoBehaviour
{
    public Text zombieKilltxt;
    public Text skeletonKilltxt;
    public Text monsterKilltxt;

    void Start()
    {
        // 마우스 커서를 보이게 안보이게
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        zombieKilltxt.text = "Zombie: " + GameManager.gameManager.total1.ToString();
        skeletonKilltxt.text = "Zombie: " + GameManager.gameManager.total2.ToString();
        monsterKilltxt.text = "Zombie: " + GameManager.gameManager.total3.ToString();
    }
}
