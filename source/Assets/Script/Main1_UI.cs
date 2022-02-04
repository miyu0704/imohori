using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main1_UI : MonoBehaviour
{
    public Text txtScore;
    public Image imgTime;

    float z;

/*    int s = 0;          //デバッグ用変数
    float e = 0.0f;     //デバッグ用変数
*/
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    //初期化処理
    public void Init()
    {
        z = 0.0f;
        txtScore.text = "0";
        imgTime.transform.rotation = Quaternion.Euler(0, 0, z);
    }


    //スコア表示
    /*
        @param score    スコア
    */
    public void Score(int score)
    {
        txtScore.text = score.ToString();
    }

    //時間表示
    /*
        @param time        現在の経過時間      
        @param maxTime     タイムリミット
    */
    public void ShowTime(float time, float maxTime)
    {
        if (z < 90.0f)
        {
            z = 90.0f * (time / maxTime);
        }
        imgTime.transform.rotation = Quaternion.Euler(0, 0, z);
    }


    // Update is called once per frame
    void Update()
    {
/*        e += Time.deltaTime;
        ShowTime(e, 10.0f);

        if(Input.GetKeyDown(KeyCode.S))
        {
            s++;
            Score(s);
        }
*/  }
}
