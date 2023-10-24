using UnityEngine;

public class MoveToCollectState : ICharacterState
{

    Character owner;

    public MoveToCollectState(Character owner)
    {
        this.owner = owner;
    }

    public void OnEnter()
    {
        if (!owner.HasStateAuthority)
        {
            return;
        }

        if (owner.WoodSource == null)
        {
            owner.CharacterStateController.ChangeState(CharacterState.Idle);
        }

        owner.SetMovability(true);

        if (CheckDistance())
        {
            owner.CharacterStateController.ChangeState(CharacterState.Collect);
        }

        owner.OnWoodSourceChanged.AddListener(GoPosition);
        GoPosition();
    }

    public void UpdateState()
    {
        if (!owner.HasStateAuthority)
        {
            return;
        }

        if (owner.WoodSource == null)
        {
            owner.CharacterStateController.ChangeState(CharacterState.Idle);
        }

        if (CheckDistance())
        {
            owner.CharacterStateController.ChangeState(CharacterState.Collect);
        }
    }

    public void OnExit()
    {
        owner.OnWoodSourceChanged.RemoveListener(GoPosition);
    }

    public void GoPosition()
    {
        owner.Seeker.StartPath(owner.transform.position, owner.WoodSource.transform.position);
    }

    public bool CheckDistance()
    {
        if (owner.WoodSource == null || owner.WoodSource.transform == null)
        {
            owner.CharacterStateController.ChangeState(CharacterState.Idle);
        }

        if (Vector3.Distance(owner.WoodSource.transform.position, owner.transform.position) < GameManager.Instance.Settings.WoodReachDestination)
        {
            return true;
        }

        return false;
    }
}
