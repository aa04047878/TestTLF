
public enum Status 
{
    None,
    /// <summary>
    /// ���q���A
    /// </summary>
    NormalStatus,
    /// <summary>
    /// �B�Ū��A
    /// </summary>
    FloatingStatus,
    /// <summary>
    /// �B�Ų��ʪ��A
    /// </summary>
    AirMoveStatus,
    /// <summary>
    /// ���ߪ��A��V��
    /// </summary>
    StandTurnLeftStatus,
    /// <summary>
    /// ���ߪ��A��V�k
    /// </summary>
    StandTurnRightStatus, 


}

/// <summary>
/// ���ʦ欰
/// </summary>
public enum MoveBehaviour
{
    None,
    /// <summary>
    /// ��
    /// </summary>
    Walk,
    /// <summary>
    /// �]
    /// </summary>
    Run,    
    /// <summary>
    /// �{�{
    /// </summary>
    Flash,     

}

/// <summary>
/// �ʧ@�欰
/// </summary>
public enum MotionBehaviour
{
    None,
    /// <summary>
    /// ��
    /// </summary>
    Jump,
    /// <summary>
    /// ����
    /// </summary>
    Stand,
    /// <summary>
    /// �D����
    /// </summary>
    NotStand,


}


/// <summary>
/// �����欰
/// </summary>
public enum ATKBehaviour
{
    None,
    /// <summary>
    /// ���q����
    /// </summary>
    NormalATK,
    /// <summary>
    /// �S�O����
    /// </summary>
    SpecialATK,
    /// <summary>
    /// ¾�~����
    /// </summary>
    ProfessionalATK,
    /// <summary>
    /// ¾�~�S�O����
    /// </summary>
    ProfessionalSpecialATK, 

}