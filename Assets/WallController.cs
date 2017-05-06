using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour {

    GameObject tire;

    void Start () {
        // タイヤオブジェクトを取得
        this.tire = GameObject.Find("Tire");
    }
	
	void Update () {
        // 背景が画面の外に出たら、Destroyする
        if (this.tire.transform.position.x - transform.position.x > 13.5f)
        {
            Destroy(gameObject);
        }
    }
}
