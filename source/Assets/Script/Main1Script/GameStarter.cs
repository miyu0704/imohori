using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    Main1_Manager MA;

    float Elapsed = 3.5f;
    string CountDown = "";

    // Start is called before the first frame update
    void Start()
    {
        MA = GetComponent<Main1_Manager>() as Main1_Manager;
        MA.txtNavi.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        Elapsed -= Time.deltaTime;
        if (Elapsed <= 0.0f)
        {
            BroadcastMessage("GameStart",
            SendMessageOptions.DontRequireReceiver); //ゲームの開始を放送する
            enabled = false; //このスクリプトは停止
        }
        else if (Elapsed < 3.0f)
        { 
            // 0.5秒経過したらカウントダウン表示を行う
             CountDown = "" + Mathf.Ceil(Elapsed); //切り上げた整数部を表示する
            MA.txtNavi.text = CountDown;
            //文字の大きさにも使っちゃいました。だんだん小さくなります。
            MA.txtNavi.fontSize = Mathf.FloorToInt((1 + (Elapsed - Mathf.Floor(Elapsed))) * 60);
        }
    }
}
