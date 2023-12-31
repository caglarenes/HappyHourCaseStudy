public class MoveState : ICharacterState
{
    Character owner;

    public MoveState(Character owner)
    {
        this.owner = owner;
    }

    public void OnEnter()
    {
        if(!owner.Object.HasStateAuthority)
        {
            return;
        }

        owner.OnMovePointChanged.AddListener(GoPosition);
        owner.SetMovability(true);
        GoPosition();
    }

    public void UpdateState()
    {
        if (owner.AIPath.reachedDestination || owner.AIPath.reachedEndOfPath)
        {
            owner.CharacterStateController.ChangeState(CharacterState.Idle);
        }
    }

    public void OnExit()
    {
        owner.OnMovePointChanged.RemoveListener(GoPosition);
    }

    public void GoPosition()
    {
        if (!owner.Object.HasStateAuthority)
        {
            return;
        }

        owner.StartPathfind(owner.transform.position, owner.MovePoint);
    }
}
