using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBackgroundController : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
        // 背景を自動スクロール
        transform.Translate(-0.05f, 0, 0);
        if (transform.position.x < -20.0f)
        {
            transform.position = new Vector3(transform.position.x + 20.44f * 2, 0, 0);
        }
    }
}
