
public enum Status 
{
    None,
    NormalStatus,         //���q���A
    FloatingStatus,       //�B�Ū��A
    AirMoveStatus,        //�B�Ų��ʪ��A
    StandTurnLeftStatus,  //���ߪ��A��V��
    StandTurnRightStatus, //���ߪ��A��V�k


}

/// <summary>
/// ���ʦ欰
/// </summary>
public enum MoveBehaviour
{
    None,
    Walk,  //��
    Run,   //�]
    Stand, //����
    Flash, //�{�{


}

/// <summary>
/// �����欰
/// </summary>
public enum ATKBehaviour
{
    None,
    NormalATK,        //���q����
    SpecialATK,       //�S�O����
    ProfessionalATK,  //¾�~����
    ProfessionalSpecialATK, //¾�~�S�O����

}