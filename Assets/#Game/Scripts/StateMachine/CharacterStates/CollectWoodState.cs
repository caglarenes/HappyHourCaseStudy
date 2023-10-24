using Pathfinding;
using System.Collections;
using System.Collections.Concurrent;
using UnityEngine;

public class CollectWoodState : ICharacterState
{

    Character owner;

    public Coroutine CollectCO;

    public CollectWoodState(Character owner)
    {
        this.owner = owner;
    }

    public void OnEnter()
    {
        owner.SetMovability(false);

        if (!owner.HasStateAuthority)
        {
            return;
        }

        CollectCO = CoroutineHolder.Instance.StartCoroutine(CollectCoroutine());
    }

    public void UpdateState()
    {
        if (!owner.HasStateAuthority)
        {
            return;
        }

        if (owner.WoodSource == null || owner.WoodSource.SourceCount <= 0)
        {
            owner.CharacterStateController.ChangeState(CharacterState.Idle);
        }
    }

    public void OnExit()
    {
        if (CollectCO != null)
        {
            CoroutineHolder.Instance.StopCoroutine(CollectCO);
        }
    }

    public IEnumerator CollectCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.3f);
            owner.WoodSource.CollectWood(10, owner.CharacterTeam);
            yield return new WaitForSeconds(0.7f);
        }
    }
}
