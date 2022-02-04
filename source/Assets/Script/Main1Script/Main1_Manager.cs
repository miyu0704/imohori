using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //シーンのロードに必要

public class Main1_Manager : MonoBehaviour
{
    //プレイ中の判定遷移
    enum Play
    {
        Ready,
        Decision,   //判定中
        True,       //成功
        False       //失敗
    }

    Play play;

    public Text txtInput;   //プレイヤーの入力
    public Text txtAnswer;  //問題
    public Text txtNavi;
    public Image imgTime;

    float Elapsed;
    float MaxTime = 30.0f;
    int Number; //問題番号 5の倍数の時は得点多め
    int score;  //掘ったイモのスコア
    int ANum;   //何文字目か
    string CountDown;

    bool AnswerTime = false;
    bool PlayNow=false;

    Main1_UI mainUI;

    public GameObject imo;
    SpriteRenderer imosprite;
    public Sprite FalseSprite;

    GameObject Player;
    GameObject clone;

    //問題
    private string[] Answer = {"","aoi","inoti","utiwa","oimo", "imohori", "obake", "kasumi","kamui","kodama","haroulin" };
    private string _Answer="";

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        mainUI = GetComponent<Main1_UI>();
        Elapsed = 0;
        Main1_Init();
        play = Play.Ready;
        
;    }

    void Main1_Init()
    {
        txtInput.text = "";
        txtAnswer.text = "";
        mainUI.Init();
        _Answer = " ";
        ANum = 0;
        PlayerPrefs.SetInt("Score", 0);

    }

    //いもの生成処理
    void CreateImo()
    {

        Instantiate(imo, new Vector2(10.5f, -3.51f), Quaternion.identity);

       clone = GameObject.FindGameObjectWithTag("imo");
        // このobjectのSpriteRendererを取得
        imosprite = clone.GetComponent<SpriteRenderer>();

    }

    //問題生成
    public void OutPut_Answer()
    {
        //問題番号のランダム
        Number = Random.Range(1, Answer.Length);

        _Answer = Answer[Number];
        txtAnswer.text = _Answer;
        txtInput.text = _Answer;

    }

    void GameStart()
    {
        CreateImo();
        Main1_Init();
        AnswerTime = true;
        PlayNow = true;

        play = Play.Decision;
        txtNavi.text = "";

        Elapsed = 0;
        score = 0;
        ANum = 0;
        CountDown = "";
}

    void NextGame()
    {
        Main1_Init();
        play = Play.Ready;
        txtNavi.text = "";

        PlayerPrefs.SetInt("Score", score);

        SceneManager.LoadScene("Main2");
    }

    void imo_delete()
    {
        var clones = GameObject.FindGameObjectsWithTag("imo");
        foreach (var clone in clones)
        {
            Destroy(clone);
        }


    }

    // Update is called once per frame
    void Update()
    {

        if (PlayNow)
        {
            Elapsed += Time.deltaTime;
            mainUI.ShowTime(Elapsed, MaxTime);
        }

        if (Elapsed >=MaxTime)
        {
            txtInput.text = "";
            txtAnswer.text = "Time UP";
            Elapsed = MaxTime;
            PlayNow = false;
            Invoke("NextGame", 1.0f);
        }
        else
        {
            switch (play)
            {
                case Play.Ready:

                    break;

                case Play.Decision:
                    if (AnswerTime)
                    {
                        OutPut_Answer();
                        AnswerTime = false;
                    }

                    //正解判定
                    if (Input.GetKeyDown(_Answer[ANum].ToString()))
                    {
                        ANum++;
                        txtInput.text = "<color=#000000>" + _Answer.Substring(0, ANum) + "</color>" + _Answer.Substring(ANum);

                        if (ANum >= _Answer.Length)
                        {
                            play = Play.True;
                            ANum = 0;
                        }

                    }
                    else if (Input.anyKeyDown)
                    {
                        ANum = 0;
                        play = Play.False;
                    }


                    break;

                case Play.True:

                    imo_delete();

                    Player.SendMessage("True", SendMessageOptions.DontRequireReceiver);
                    if (Number % 5 == 0)
                    {
                        score += 3;
                    }
                    else
                    {
                        score++;
                    }
                    mainUI.Score(score);
                    txtInput.text = "";
                    Invoke("CreateImo", 0.5f);
                    AnswerTime = true;


                    play = Play.Decision;

                    break;

                case Play.False:
                    Player.SendMessage("False", SendMessageOptions.DontRequireReceiver);
                    imosprite.sprite = FalseSprite;
                    Invoke("imo_delete", 0.5f);
                    txtInput.text = "";
                    Invoke("CreateImo", 0.7f);
                    AnswerTime = true;

                    play = Play.Decision;
                    break;
            }
            
        }

    }
}
