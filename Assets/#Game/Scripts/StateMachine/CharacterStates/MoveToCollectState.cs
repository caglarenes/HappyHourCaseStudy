public class MoveToCollectState : ICharacterState
{

    Character owner;

    public MoveToCollectState(Character owner)
    {
        this.owner = owner;
    }

    public void OnEnter()
    {

    }

    public void UpdateState()
    {
    }

    public void OnExit()
    {

    }
}
