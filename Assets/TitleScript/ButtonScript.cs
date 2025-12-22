using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    private bool firstPush = false;

    //スタートボタンが押されたら呼ばれる

    public void PressStart()
    {
        if (!firstPush)
        {

            firstPush = true;

            //シーン切り替え
            SceneManager.LoadScene("StageScene");
        }
    }
}
