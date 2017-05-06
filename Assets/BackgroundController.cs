using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {

    GameObject tire;

    void Start()
    {
        // タイヤオブジェクトを取得
        this.tire = GameObject.Find("Tire");
    }

    void Update()
    {
        // 背景が画面の外に出たら、前方に移動する(無限ループ)
        if (this.tire.transform.position.x - transform.position.x > 13.5f)
        {
            transform.position = new Vector3(transform.position.x + 20.44f * 2, 0, 0);      // 背景は2つ有るため、移動距離を2倍にする
        }


    }
}
