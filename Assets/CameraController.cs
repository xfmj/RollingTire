using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    GameObject tire;
    Rigidbody2D rb;
    Vector3 tirePos;
    float time;

    void Start () {
        // タイヤオブジェクトを取得
        this.tire = GameObject.Find("Tire");
	}

	void Update () {
        // タイヤの位置を取得
        tirePos = this.tire.transform.position;
        rb = this.tire.GetComponent<Rigidbody2D>();

        if (tirePos.x > -6.0f) {
            // プラス方向のみ
            if (rb.velocity.x >= 0)
            {
                // カメラのx軸をタイヤの位置と同調する
                transform.position = new Vector3(tirePos.x + 6.0f, transform.position.y, transform.position.z);
            }
        }
	}
}
