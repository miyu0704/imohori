using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImoAction : MonoBehaviour
{
    Main1_Manager manager;

    float moveSpeed;        //移動速度
    Vector2 move_Position;  //移動させたいオブジェクトの現在地
    Vector2 toGoPoint;      //移動目的地


    // Start is called before the first frame update
    void Start()
    {
        move_Position = this.transform.position;
        toGoPoint = new Vector2(-1.2f, -3.51f);
        moveSpeed = 0.05f;
    }

    //void False()
    //{
    //    Debug.Log("False");
    //    //画像を変える
    //    mysprite.sprite = FalseSprite;
    //}


    // Update is called once per frame
    void Update()
    {
        if (move_Position.x > toGoPoint.x)
        {
            move_Position.x-= moveSpeed;
            this.transform.position = move_Position;
        }
    }
}
