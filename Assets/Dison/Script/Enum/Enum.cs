
public enum Status 
{
    None,
    /// <summary>
    /// 普通狀態
    /// </summary>
    NormalStatus,
    /// <summary>
    /// 浮空狀態
    /// </summary>
    FloatingStatus,
    /// <summary>
    /// 浮空移動狀態
    /// </summary>
    AirMoveStatus,
    /// <summary>
    /// 站立狀態轉向左
    /// </summary>
    StandTurnLeftStatus,
    /// <summary>
    /// 站立狀態轉向右
    /// </summary>
    StandTurnRightStatus, 


}

/// <summary>
/// 移動行為
/// </summary>
public enum MoveBehaviour
{
    None,
    /// <summary>
    /// 走
    /// </summary>
    Walk,
    /// <summary>
    /// 跑
    /// </summary>
    Run,
    /// <summary>
    /// 站立
    /// </summary>
    Stand,
    /// <summary>
    /// 閃現
    /// </summary>
    Flash, 
    /// <summary>
    /// 跳
    /// </summary>
    Jump,



}

/// <summary>
/// 攻擊行為
/// </summary>
public enum ATKBehaviour
{
    None,
    /// <summary>
    /// 普通攻擊
    /// </summary>
    NormalATK,
    /// <summary>
    /// 特別攻擊
    /// </summary>
    SpecialATK,
    /// <summary>
    /// 職業攻擊
    /// </summary>
    ProfessionalATK,
    /// <summary>
    /// 職業特別攻擊
    /// </summary>
    ProfessionalSpecialATK, 

}