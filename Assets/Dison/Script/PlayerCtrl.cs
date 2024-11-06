using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector3 directionRight;
    public Vector3 directionLeft;
    public Vector3 directionUp;
    public Vector3 directionDown;
    public float power;
    public float gravity;
    /*    
    經過我的觀察，
    跳　>> AddForce
    移動 >> velocity
    */

    /// <summary>
    /// 玩家移動
    /// </summary>
    public void PlayerMove()
    {
        ////向上移動
        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    // "=" : 移動速度不疊加
        //    power = 5;
        //    rd.velocity = directionUp * power;
        //}

        ////向下移動
        //if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    // "=" : 移動速度不疊加
        //    power = 5;
        //    rd.velocity = directionDown * power;
        //}

        //向左移動
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // "=" : 移動速度不疊加
            power = 5;
            rb.velocity = directionLeft * power;
            //rb.AddForce(directionLeft * power);
        }

        //向右移動
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // "=" : 移動速度不疊加
            power = 5;
            rb.velocity = directionRight * power;
            //rb.AddForce(directionRight * power);
            Debug.Log($"向右移動的power : {power}");
        }

        ////停止向上移動
        //if (Input.GetKeyUp(KeyCode.UpArrow))
        //{
        //    power = 0;
        //    rd.velocity = directionUp * power;
        //}

        ////停止向下移動
        //if (Input.GetKeyUp(KeyCode.DownArrow))
        //{
        //    power = 0;
        //    rd.velocity = directionDown * power;
        //}

        //停止向左移動
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            power = 0;
            rb.velocity = directionLeft * power;
            //rb.AddForce(directionLeft * power);
        }

        //停止向右移動
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            power = 0;
            rb.velocity = directionRight * power;
            //rb.AddForce(directionRight * power);
            Debug.Log($"停止向右移動的power : {power}");
        }

        //跳(連續案就是N段跳)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            power = 5;
            rb.velocity = directionUp * power;
            //rb.AddForce(directionUp * power);
            Debug.Log($"跳的power : {power}");
        }

        Physics.gravity = new Vector3(0, gravity, 0);  // gravity= -35 其他的默认
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }
}
