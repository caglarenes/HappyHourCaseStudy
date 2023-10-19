using Fusion;

public interface IGameState : IState
{
    public GameState StateEnum { get; set; }
    public NetworkRunner NetworkRunner { get; set; }

}
