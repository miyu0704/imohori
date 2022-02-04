using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main2_UI : MonoBehaviour
{
    public Text txtRemain;
    public Text txtScore;
    public Text txtWeight;

/*    int r = 0;     //デバッグ用変数
    int s = 0;      //デバッグ用変数
    float w = 0.0f;     //デバッグ用変数
*/
    // Start is called before the first frame update
    void Start()
    {
        //初期化処理
        Init();   
    }


    //初期化処理
    public void Init()
    {
        txtRemain.text = "0";
        txtScore.text = "0";
        txtWeight.text = "---.--";
    }


    //残り回数表示
    /*
        @param remain   残り回数（個数）
    */
    public void Remain(int remain)
    {
        txtRemain.text = remain.ToString();
    }


    //スコア表示
    /*
        @param score    スコア 
    */
    public void Score(int score)
    {
        txtScore.text = score.ToString();
    }


    //重量表示
    /*
        @param weight   重量
    */
    public void Weight(float weight)
    {
        txtWeight.text = weight.ToString("f2").PadLeft(6);
    }


    // Update is called once per frame
    void Update()
    {
/*        if(Input.GetKeyDown(KeyCode.R))
        {
            r++;
            Remain(r);
        }

        if(Input.GetKeyDown(KeyCode.W))
        {
            w = Random.Range(50.0f, 250.0f);
            Weight(w);
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            s += 100;
            Score(s);
        }
*/    }
}
