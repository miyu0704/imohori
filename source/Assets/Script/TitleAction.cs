using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleAction : MonoBehaviour
{
    //== タイトルシーン ==//
    public Image imgTitle;      
    public Button btnStart1;
    public Button btnStart2;

    public AudioClip SE_Select;
    AudioSource myAudio;

    float Elapsed = 0.0f;
    bool isLoad = false;

    // Start is called before the first frame update
    void Start()
    {
        myAudio = gameObject.GetComponent<AudioSource>();
        TitleInit();
    }

   
    //タイトル：初期化
    void TitleInit()
    {
        Elapsed = 0.0f;
        isLoad = false;
        
        myAudio.Play();
    }


    //タイトル：btnStart1
    public void BtnStart1()
    {
        myAudio.PlayOneShot(SE_Select);
        isLoad = true;
    }


    //タイトル：btnStart2
    public void BtnStart2()
    {
        myAudio.PlayOneShot(SE_Select);
        Debug.Log("チュートリアル表示");
    }


    // Update is called once per frame
    void Update()
    {
        if(isLoad)
        {
            Elapsed += Time.deltaTime;
            if(Elapsed >= 0.5f)
            {
                SceneManager.LoadScene("Main1");
            }
        }
    }
}
