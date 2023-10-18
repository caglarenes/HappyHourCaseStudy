public enum CharacterState : byte
{
    Idle,
    Walk,
    Collect
}

public class CharacterNetworkStateMachine : NetworkedStateMachine<CharacterState>
{

}
