using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour
{
    [Header("玩家移動")]
    public Rigidbody2D rb;
    public Vector3 directionRight;
    public Vector3 directionLeft;
    public Vector3 directionUp;
    public Vector3 directionDown;
    public float power;
    public float gravity;
    /// <summary>
    /// 移動變數(水平)
    /// </summary>
    float moveVariableHor;

    /// <summary>
    /// 移動變數(垂直)
    /// </summary>
    float moveVariableVer;

    /// <summary>
    /// 跳的次數
    /// </summary>
    int jumpTimes;

    /// <summary>
    /// 現在的狀態
    /// </summary>
    public Status nowStatus;

    [Header("耐力")]
    /// <summary>
    /// 最大耐力
    /// </summary>
    public float maxStamina;

    /// <summary>
    /// 目前的耐力
    /// </summary>
    public float nowStamina;

    /// <summary>
    /// 耐力條
    /// </summary>
    public Image staminaBar;

    /// <summary>
    /// 耐力已耗盡
    /// </summary>
    bool staminaEmpty;
    /*    
    經過我的觀察，
    跳　>> AddForce
    移動 >> velocity
    */

    #region 玩家移動
    /// <summary>
    /// 浮空狀態移動
    /// </summary>
    private void FloatingStatusMove(float moveVariableHor, float moveVariableVer)
    {

        //if (rb.bodyType == RigidbodyType2D.Static) //在浮空狀態下，才能上下移動
        //{
        //    if (moveVariableVer > 0) //往上移動
        //    {
        //        rb.bodyType = RigidbodyType2D.Dynamic; //在Static狀態下無法移動

        //        nowStatus = Status.AirMoveStatus;
        //        Debug.Log("moveVariableVer : " + moveVariableVer);
        //    }
        //    else if (moveVariableVer < 0) //往下移動
        //    {
        //        rb.bodyType = RigidbodyType2D.Dynamic; //在Static狀態下無法移動

        //        nowStatus = Status.AirMoveStatus;
        //        Debug.Log("moveVariableVer : " + moveVariableVer);
        //    }
        //    else //沒移動
        //    {
        //        nowStatus = Status.FloatingStatus; //浮空狀態
        //        rb.bodyType = RigidbodyType2D.Static; //浮空狀態
        //        Debug.Log("moveVariableVer : " + moveVariableVer);
        //        Debug.Log("沒移動");
        //    }
        //}

        if (nowStatus == Status.FloatingStatus) //在浮空狀態下，才能上下移動
        {
            if (moveVariableVer == 0 && moveVariableHor == 0) //沒有移動
            {
                nowStatus = Status.FloatingStatus; //浮空狀態
                rb.bodyType = RigidbodyType2D.Static;
                //Debug.Log("moveVariableVer : " + moveVariableVer);
                Debug.Log("沒移動");
            }
            else
            {
                //有移動
                rb.bodyType = RigidbodyType2D.Dynamic; //在Static狀態下無法移動
                nowStatus = Status.AirMoveStatus; //浮空移動狀態
                //Debug.Log("moveVariableVer : " + moveVariableVer);
            }
        }


        if (nowStatus == Status.AirMoveStatus)
        {
            if (moveVariableVer == 0 && moveVariableHor == 0)
            {
                nowStatus = Status.FloatingStatus; //浮空狀態
                rb.bodyType = RigidbodyType2D.Static; //浮空狀態
                Debug.Log("moveVariableVer : " + moveVariableVer);
                Debug.Log("沒移動");
            }
            else
            {
                //power = 5;
                ////                    方向   * 力道  * (1「上」 / -1 「下」)
                //rb.velocity = (directionUp + directionRight) * power * ((moveVariableVer + moveVariableHor) / 2);

                //power = 5;
                ////                    方向   * 力道  * (1「上」 / -1 「下」)
                //rb.velocity = directionUp * power * moveVariableVer;

                //浮空狀態移動
                Vector3 movement = new Vector3(moveVariableHor, moveVariableVer, 0);
                Debug.Log($"movement : {movement}");
                rb.velocity = movement * power;
            }
        }
    }

    /// <summary>
    /// 普通狀態移動
    /// </summary>
    private void NormalStatusMove(float moveVariableHor)
    {
        //if (moveVariableHor > 0) //往右移動
        //{
        //    power = 5;
        //    //                    方向   * 力道  * (1「右」 / -1 「左」)  * 角色的重力(後面2個)
        //    rb.velocity = directionRight * power * moveVariableHor + directionUp * rb.velocity.y;
        //    Debug.Log("往右移動");
        //}
        //else if (moveVariableHor < 0) //往左移動
        //{
        //    power = 5;
        //    //                    方向   * 力道  * (1「右」 / -1 「左」)  * 角色的重力 (後面2個)
        //    rb.velocity = directionRight * power * moveVariableHor + directionUp * rb.velocity.y;
        //    Debug.Log("往左移動");
        //}
        //else //沒移動
        //{
        //    power = 0;
        //    //                  方向    * 力道  * (1「右」 / -1 「左」) * 角色的重力 (後面2個)
        //    rb.velocity = directionDown * power * moveVariableHor + directionUp * rb.velocity.y;
        //    //Debug.Log("沒移動");
        //}

        if (nowStatus == Status.NormalStatus)
        {
            Vector3 movement = new Vector3(moveVariableHor, 0, 0);
            //Debug.Log($"movement : {movement}");
            rb.velocity = movement * power + directionUp * rb.velocity.y;
        }
    }

    /// <summary>
    /// 移動
    /// </summary>
    /// <param name="moveVariableHor">水平移動變數</param>
    /// <param name="moveVariableVer">垂直移動變數</param>
    private void Move(float moveVariableHor, float moveVariableVer)
    {
        NormalStatusMove(moveVariableHor);
        FloatingStatusMove(moveVariableHor, moveVariableVer);
    }

    /// <summary>
    /// 跳
    /// </summary>
    private void Jump()
    {
        //跳(連續案就是N段跳(如果沒有限制的話))
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpTimes++;
            if (nowStatus == Status.FloatingStatus) //在浮空狀態下再按一次跳
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
                nowStatus = Status.NormalStatus; //變回普通狀態
                jumpTimes = 0; //跳的次數重新計算
            }
            else if (jumpTimes == 1)
            {
                power = 5;
                rb.velocity = directionUp * power;
                Debug.Log("跳一次");
                //rb.AddForce(directionUp * power);
                //Debug.Log($"跳的power : {power}");
            }
            else if (jumpTimes == 2 && !staminaEmpty) //耐力沒耗盡的情況下按2次跳，才能浮空
            {
                //Static狀態下，物體不會移動，正在物理移動中的物體會瞬間停止。
                rb.bodyType = RigidbodyType2D.Static;
                nowStatus = Status.FloatingStatus; //浮空狀態
                Debug.Log("跳二次");
            }
        }
    }

    /// <summary>
    /// 玩家移動
    /// </summary>
    public void PlayerMove()
    {
        #region Input.GetKey
        /*
        Input.GetKey() : 
        只有在按鍵盤的時候才會有反應，然而角色的重力是時時刻刻存在的，所以移動角色不要用。
        */
        #endregion

        #region Input.GetAxis
        /*
        Input.GetAxis() :
        會返還一個float，往左(A、←)float = -1，往右(D、→)float = 1，都沒按float = 0
        可以用返還的float來間接當作控制移動的參數。
        */
        moveVariableHor = Input.GetAxis("Horizontal"); //水平移動
        moveVariableVer = Input.GetAxis("Vertical"); //垂直移動
        #endregion

        Jump();
        Move(moveVariableHor, moveVariableVer);
    }
    #endregion

    #region 玩家消耗
    /// <summary>
    /// 消耗耐力
    /// </summary>
    public void ConsumeStamina()
    {
        if (nowStatus != Status.None && nowStatus != Status.NormalStatus)
        {
            nowStamina -= Time.deltaTime * 10; //每秒消耗10點耐力
            staminaBar.transform.localPosition = new Vector3((-250 + 250 * (nowStamina / maxStamina)), 0f, 0f);
        }
    }

    /// <summary>
    /// 玩家消耗
    /// </summary>
    public void PlayerConsume()
    {
        ConsumeStamina();
    }

    #endregion

    #region 玩家疲憊
    /// <summary>
    /// 玩家疲憊
    /// </summary>
    public void PlayerTired()
    {
        StaminaEmpty();
    }

    /// <summary>
    /// 耐力消耗殆盡
    /// </summary>
    public void StaminaEmpty()
    {
        if (staminaEmpty) //耐力已耗盡
            return;

        if (nowStamina <= 0)
        {
            nowStamina = 0;
            nowStatus = Status.NormalStatus; //變回普通狀態
            rb.bodyType = RigidbodyType2D.Dynamic;
            staminaEmpty = true;
            Debug.Log("耐力消耗殆盡");
        }
    }
    #endregion

    /// <summary>
    /// 初始化
    /// </summary>
    public void Init()
    {
        jumpTimes = 0;
        nowStamina = 100f;
        maxStamina = 100f;
        nowStatus = Status.NormalStatus;
    }

    /// <summary>
    /// 玩家行為
    /// </summary>
    public void PlayerBehaviour()
    {
        PlayerMove();
        PlayerConsume();
        PlayerTired();
    }

    private void OnCollisionEnter2D(Collision2D hit)
    {
        //hit就是指碰撞到的Collision(打到的對方)
        //						碰撞到的物體的名稱
        Debug.Log("Enter  hit.transform.tag : " + hit.transform.tag);
        if (hit.transform.tag == "Floor") //玩家碰到地板
        {
            jumpTimes = 0; //跳次數重製
            rb.bodyType = RigidbodyType2D.Dynamic; //解除浮空狀態
            nowStatus = Status.NormalStatus;
        }
    }

    

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerBehaviour();
    }
}
