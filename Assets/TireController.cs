using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TireController : MonoBehaviour {

    Rigidbody2D rigid2D;
    private AudioSource hitSound1;              // 地面ヒット音
    private AudioSource hitSound2;              // 壁ヒット音
    Slider charger;                                         // エネルギーバー

    bool charged;                                          // 連続クリック防止用フラグ
    public Text movedText;                            // 移動距離表示UI用

    // タイマー用
    int minite;
    float second;
    int oldSecond;
    bool timerFlag;
    public Text timeText;

    float time;
    float pushForce = 400.0f;                        // 初速度用
    float gameOvertime;                                // ゲームオーバー用タイマー
    public static double movedMeter;            // 移動距離メタ

    void Start () {
        charged = false;
        movedText.text = "Moved   : 0 m";
        timeText.text = "Time      : 00:00";
        gameOvertime = 0f;
        movedMeter = 0f;
        minite = 0;
        second = 0f;
        oldSecond = 0;

        // 効果音初期化用
        this.rigid2D = GetComponent<Rigidbody2D>();
        AudioSource[] audioSources = GetComponents<AudioSource>();
        hitSound1 = audioSources[0];
        hitSound2 = audioSources[1];
        charger = GameObject.Find("charger").GetComponent<Slider>();

        // 初期速度を与える
        this.rigid2D.AddForce(transform.right * pushForce);
    }
	
	void Update () {
        // タイヤのスピードが逆になったら2秒後にゲームオーバー画面へ遷移する
        if (this.rigid2D.velocity.x < 0)
        {
            gameOvertime += Time.deltaTime;
            if (gameOvertime > 2.0f)
            {
                SceneManager.LoadScene("gameOver");
            }
            return;
        }

        // クリックイベント
        if ((Input.GetMouseButton(0) || Input.touchCount > 0) && charged)
        {
            Vector3 clickPos;

            // マウスクリック
            if (Input.GetMouseButton(0)) {
                // クリックされた場所の座標を取得
                clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
            else   // タップ
            {
                Touch touch = Input.GetTouch(0);
                clickPos = Camera.main.ScreenToWorldPoint(touch.position);
            }
            // タイヤとクリックされた場所の方向を計算する
            Vector3 dir = clickPos - transform.position;

            // 加速度制限
            if (dir.x > 6.0f) { dir.x = 6.0f; }
            if (dir.y > 6.0f) { dir.y = 6.0f; }
            if (dir.y < -6.0f) { dir.y = -6.0f; }

            //this.rigid2D.AddForce(new Vector2(1, 3) * 150);
            // 力を加える
            this.rigid2D.AddForce((dir) * 50.0f);
            charged = false;
        }

        // 最大速度制限
        if (this.rigid2D.velocity.x > 10.0f || this.rigid2D.velocity.y > 12.0f || this.rigid2D.velocity.y < -12.0f)
        {
            Vector2 limitSpeed;
            if (this.rigid2D.velocity.x > 10.0f)
            {
                limitSpeed = new Vector2(10.0f, this.rigid2D.velocity.y);
            }
            else if (this.rigid2D.velocity.y > 12.0f)
            {
                limitSpeed = new Vector2(this.rigid2D.velocity.x, 12.0f);
            }
            else if (this.rigid2D.velocity.y < -12.0f)
            {
                limitSpeed = new Vector2(this.rigid2D.velocity.x, -12.0f);
            }
            else
            {
                limitSpeed = new Vector2(this.rigid2D.velocity.x, this.rigid2D.velocity.y);
            }
            this.rigid2D.velocity = limitSpeed;
        }

        // 経過時間を計算
        if (Time.timeScale > 0)
        {
            second += Time.deltaTime;
            if (second >= 60.0f)
            {
                minite++;
                second = second - 60;
            }
            if ((int)second != oldSecond)
            {
                timeText.text = "Time      : " + minite.ToString("00") + ":" + second.ToString("00");
            }
            oldSecond = (int)second;
        }

        // 移動距離をUIに反映する
        movedMeter = Math.Round((transform.position.x + 10), 0);
        movedText.text = "Moved   : " + movedMeter.ToString() + " m";

        // エネルギーバーコントローラ
        if (charged == true)
        {
            if (charger.value < 1f) {
                charger.value += 0.05f;
            }
        }
        else
        {
            if (charger.value > 0f)
            {
                charger.value -= 0.05f;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        // 接地判定処理
        if (collision.gameObject.name.Contains("Background_City"))
        {
            hitSound1.PlayOneShot(hitSound1.clip);
            charged = true;
        }
        // 壁接触処理
        if (collision.gameObject.name.Contains("WallPrefab"))
        {
            hitSound2.PlayOneShot(hitSound2.clip);
            charged = false;
        }
    }

    // 最終得点のGetter
    public static string getHitPoint()
    {
        return movedMeter.ToString();
    }
}
