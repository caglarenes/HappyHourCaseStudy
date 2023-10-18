public enum GameState : byte
{
    Null,
    Start,
    Run,
    Dead
}

public class GameStateMachine : NetworkedStateMachine<GameState>
{

}
