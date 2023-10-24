public enum CharacterState : byte
{
    Idle,
    Walk,
    MoveToCollect,
    Collect
}

public class CharacterNetworkStateMachine : NetworkedStateMachine<CharacterState>
{

}
