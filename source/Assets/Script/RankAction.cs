using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RankAction : MonoBehaviour
{
    //== リザルトシーン ==//
    public Button btnTitle;
    public Text txtScore;
    public Text[] txtRank = new Text[3];

    public AudioClip SE_Select;
    AudioSource myAudio;

    int Score = 0;
    int[] Rank = new int[3];

    float Elapsed = 0.0f;
    bool isLoad = false;


    // Start is called before the first frame update
    void Start()
    {
        myAudio = gameObject.GetComponent<AudioSource>();
        ResultInit();
    }

    //リザルト：初期化
    void ResultInit()
    {
        isLoad = false;

        Ranking();
        txtScore.text = Score.ToString();
        for(int i = 0; i < 3; i++)
        {
            txtRank[i].text = Rank[i].ToString();
        }

        myAudio.Play();
    }

    //リザルト：ランキング処理
    void Ranking()
    {
        //Main2から引き継いだスコアの読み込み
        if (PlayerPrefs.HasKey("Score"))
        {
            Score = PlayerPrefs.GetInt("Score");
            Debug.Log("スコアを読み込みました");
        }
        else
        {
            Score = 0;
            Debug.Log("スコアが存在しません");
        }

        //ランキングの読み込み
        if (PlayerPrefs.HasKey("R0"))
        {
            for (int i = 0; i < 3; i++)
            {
                Rank[i] = PlayerPrefs.GetInt("R" + i);
            }
            Debug.Log("ランキングを読み込みました");
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                Rank[i] = 0;
                PlayerPrefs.SetInt("R" + i, 0);
            }
            Debug.Log("ランキングを初期化しました");
        }

        //ランキング処理
        int newRank = 10;
        for(int i = 2; i >= 0; i--)
        {
            if(Rank[i] < Score)
            {
                newRank = i;
            }
        }
        if (newRank != 10)
        {
            for(int i = 2; i > newRank; i--)
            {
                 Rank[i] = Rank[i - 1];
            }
            Rank[newRank] = Score;
            for(int i = 0; i < 3; i++)
            {
                PlayerPrefs.SetInt("R" + i, Rank[i]);
            }
        }
    }

    //リザルト：btnTitle
    public void BtnTitle()
    {
        myAudio.PlayOneShot(SE_Select);
        isLoad = true;
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            for (int i = 0; i < 3; i++)
            {
                PlayerPrefs.DeleteKey("R" + i);
            }
            Debug.Log("ランキングを削除しました");
        }

        if (isLoad)
        {
            Elapsed += Time.deltaTime;
            if (Elapsed > 0.5f)
            {
                SceneManager.LoadScene("Title");
            }
        }
    }
}
