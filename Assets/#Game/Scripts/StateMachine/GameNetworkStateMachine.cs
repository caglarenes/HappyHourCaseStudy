public enum GameState : byte
{
    None,
    Preparation,
    CreateWood,
    Collect,
    End
}

public class GameNetworkStateMachine : NetworkedStateMachine<GameState>
{

}
