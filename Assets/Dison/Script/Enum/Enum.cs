
public enum Status 
{
    None,
    NormalStatus,         //普通狀態
    FloatingStatus,       //浮空狀態
    AirMoveStatus,        //浮空移動狀態
    StandTurnLeftStatus,  //站立狀態轉向左
    StandTurnRightStatus, //站立狀態轉向右


}

/// <summary>
/// 移動行為
/// </summary>
public enum MoveBehaviour
{
    None,
    Walk,  //走
    Run,   //跑
    Stand, //站立
    Flash, //閃現


}

/// <summary>
/// 攻擊行為
/// </summary>
public enum ATKBehaviour
{
    None,
    NormalATK,        //普通攻擊
    SpecialATK,       //特別攻擊
    ProfessionalATK,  //職業攻擊
    ProfessionalSpecialATK, //職業特別攻擊

}