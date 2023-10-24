public class IdleState : ICharacterState
{

    Character owner;

    public IdleState(Character owner)
    {
        this.owner = owner;
    }

    public void OnEnter()
    {
        owner.SetMovability(false);
    }

    public void UpdateState()
    {
    }

    public void OnExit()
    {

    }
}
