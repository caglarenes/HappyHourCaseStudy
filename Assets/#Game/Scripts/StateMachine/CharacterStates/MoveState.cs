public class MoveState : ICharacterState
{

    Character owner;

    public MoveState(Character owner)
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
