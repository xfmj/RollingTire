using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class WallGenerator : MonoBehaviour {

    GameObject tire;
    public GameObject wallPrefab;
    float spanSpace = 20.0f;
    float span = 0f;
    int wallLevel;
    System.Random rd = new System.Random();

    void Start () {
        // タイヤオブジェクトを取得
        this.tire = GameObject.Find("Tire");
    }
	
	void Update () {
        // 20単位で壁を生成する
        if (this.tire.transform.position.x > span)
        {
            GameObject newWall = Instantiate(wallPrefab) as GameObject;

            span = span + spanSpace;

            newWall.transform.position = new Vector3(span, -3.1f ,0);

            wallLevel = rd.Next(2);

            if (wallLevel == 1)
            {
                GameObject newWallLevel2 = Instantiate(wallPrefab) as GameObject;
                newWallLevel2.transform.position = new Vector3(span, -0.54f, 0);
            }
        }

    }
}
