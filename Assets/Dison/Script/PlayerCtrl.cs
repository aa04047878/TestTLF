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
    /// <summary>
    /// 移動變數
    /// </summary>
    float moveVariable;
    //float moveVariableVer;
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

        #region Input.GetKey
        /*
        Input.GetKey() : 
        只有在按鍵盤的時候才會有反應，然而角色的重力是時時刻刻存在的，所以移動角色不要用
        */
        
        //跳(連續案就是N段跳)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            power = 5;
            rb.velocity = directionUp * power;
            //rb.AddForce(directionUp * power);
            //Debug.Log($"跳的power : {power}");
        }
        #endregion

        #region Input.GetAxis
        /*
        Input.GetAxis() :
        會返還一個float，往左(A、←)float = -1，往右(D、→)float = 1，都沒按float = 0
        控制方向的參數 : moveVariable
        */
        moveVariable = Input.GetAxis("Horizontal");
        
        if (moveVariable > 0) //往右移動
        {            
            power = 5;
            //方向 * 力道 * (1「右」 / -1 「左」) * 角色的重力
            rb.velocity = directionRight * power * moveVariable + directionUp * rb.velocity.y;
        }
        else if (moveVariable < 0) //往左移動
        {
            power = 5;
            //方向 * 力道 * (1「右」 / -1 「左」) * 角色的重力 
            rb.velocity = directionRight * power * moveVariable + directionUp * rb.velocity.y;
        }
        else //沒移動
        {
            power = 0;
            //方向 * 力道 * (1「右」 / -1 「左」) * 角色的重力 
            rb.velocity = directionDown * power * moveVariable + directionUp * rb.velocity.y;
        }
        //Input.GetAxis("Horizontal");
        #endregion
        //Physics.gravity = new Vector3(0, gravity, 0);  // gravity= -35 其他的默认
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
