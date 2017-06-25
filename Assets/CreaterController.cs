using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreaterController : MonoBehaviour {

    public GameObject dummyBtn;
    public GameObject createrBtn;
    public GameObject createrPanel;

    //製作者ボタンイベント
    public void Creater()
    {
        // ボタン制御
        createrPanel.SetActive(true);
        createrBtn.SetActive(false);
        dummyBtn.SetActive(false);
    }

    // 閉じるボタンイベント
    public void Close()
    {
        // ボタン制御
        createrPanel.SetActive(false);
        createrBtn.SetActive(true);
        dummyBtn.SetActive(true);
    }
}
