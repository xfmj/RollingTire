using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour {

    public Text scoreText;
    string score;

    void Start () {
        // 最終得点を表示
        this.score = TireController.getHitPoint();
        this.scoreText.text = "Score : " + this.score + " m";
    }
	
	void Update () {
        // クリックで最初の画面に戻る
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("startMenu");
        }
    }
}
