using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    
    Animator MyAnim; // 自身のアニメーター

    //int Combo = 0;  //連続正解時


    // Start is called before the first frame update
    void Start()
    {
        MyAnim = GetComponent<Animator>(); // 自身のアニメーターを取得
        PlayerReset();
    }

    void PlayerReset()
    {
        
    }

    void True()
    {
        MyAnim.SetTrigger("True");
    }

    void False()
    {
        MyAnim.SetTrigger("False");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
