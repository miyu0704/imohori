using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main2Manager : MonoBehaviour
{
    public enum Play
    {
        Wait,
        AnswerTime,
        True,
        False,
        End
    }

    Main2_UI mainUI;

    public Play play;

    int score;
    int Remain;
    int Weight;

    bool IsPush = false;

    public Text txtNavi;

    public GameObject imo;
    SpriteRenderer imosprite;
    public Sprite[] imoSprites = new Sprite[3];


    GameObject Boxes;
    int BoxNumber = 0;
    int WeightNumber = 0;

    float moveSpeed;        //移動速度
    Vector2 move_Position;  //移動させたいオブジェクトの現在地
    Vector2 toGoPoint;      //移動目的地

    int imo_Number = 0;

    void Start()
    {
        mainUI = GetComponent<Main2_UI>();
        Main2_Init();
        PlayerPrefs.SetInt("Score", 10);

        move_Position = imo.transform.position;
        toGoPoint = new Vector2(0,3.8f);
        moveSpeed = 0.05f;

        imosprite = imo.GetComponent<SpriteRenderer>();
    }

    void Main2_Init()
    {

        play = Play.Wait;
        Weight = 0;
        score = 0;
        Weight = 0;

        Remain = PlayerPrefs.GetInt("Score");

        mainUI.Init();
    }

    void GameStart()
    {

        Main2_Init();
        play = Play.AnswerTime;
        txtNavi.text = "";
        score = 0;
        imo_Number = 0;

        imo_Create();

        mainUI.Remain(Remain);
        mainUI.Score(0);
        mainUI.Weight(Weight);


    }

    void imo_Create()
    {
        Weight = Random.Range(50, 300);

        if (Weight <= 100)
        {
            WeightNumber = 0;
        }
        else if (Weight <= 200)
        {
            WeightNumber = 1;
        }
        else
        {
            WeightNumber = 2;
        }


    }

    //判定処理
    void Decision()
    {
        if (WeightNumber == BoxNumber)
        {

            play = Play.True;
        }
        else
        {
            play = Play.False;
        }

    }

    public void OnButtonClick(int BoxNum)
    {
        IsPush = true;
        BoxNumber = BoxNum;
    }

    void Playing()
    {
        Remain--;
        mainUI.Score(score);
        mainUI.Remain(Remain);

        play = Play.AnswerTime;
        IsPush = false;

        move_Position.y = 7.0f;
        imo.transform.position = move_Position;

        int imosp = Random.Range(0, 2);
        imosprite.sprite = imoSprites[imosp];

        if (Remain<=0)
        {
            Remain = 0;
            play = Play.End;
        }

        Invoke("imo_Create", 0.5f);
    }

    void NextGame()
    {
        play = Play.Wait;
        txtNavi.text = "";
        PlayerPrefs.SetInt("Score", score);

        SceneManager.LoadScene("Rank");
    }

    // Update is called once per frame
    void Update()
    {
        switch (play)
        {
            case Play.Wait:
                break;

            case Play.AnswerTime:

                if (move_Position.y > toGoPoint.y)
                {
                    move_Position.y -= moveSpeed;
                    imo.transform.position = move_Position;

                }
                mainUI.Weight(Weight);
                if (IsPush)
                {
                    Decision();
                }
                break;

            case Play.True:
                score += 100;
                Playing();
                break;

            case Play.False:
                if (score - 50 > 0)
                {
                    score -= 50;
                }
                else
                {
                    score = 0;
                }
                Playing();
                break;

            case Play.End:
                txtNavi.text = "TIME UP!!";

                Invoke("NextGame", 1.0f);
                break;
        }
    }
}
