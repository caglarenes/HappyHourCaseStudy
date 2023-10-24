using Fusion;
using UnityEngine;
using Pathfinding;
using UnityEngine.Events;
using static UnityEngine.UI.GridLayoutGroup;

public class Character : NetworkBehaviour
{
    [Networked(OnChanged = nameof(OnCharacterTeamChanged))]
    public Team CharacterTeam { get; set; }

    public CharacterNetworkStateMachine CharacterNetworkStateMachine;
    public CharacterStateMachine CharacterStateMachine;
    public CharacterStateController CharacterStateController;

    public Seeker Seeker;
    public AIPath AIPath;

    public MeshRenderer CharacterMeshRenderer;

    public Vector3 MovePoint;
    [HideInInspector]
    public UnityEvent OnMovePointChanged = new();

    public WoodSource WoodSource;
    [HideInInspector]
    public UnityEvent OnWoodSourceChanged = new();

    #region Setup
    public override void Spawned()
    {
        ChangeCharacterTeam(CharacterTeam);
    }

    public static void OnCharacterTeamChanged(Changed<Character> changed)
    {
        changed.Behaviour.ChangeCharacterTeam(changed.Behaviour.CharacterTeam);
    }

    public void ChangeCharacterTeam(Team characterTeam)
    {
        if (CharacterTeam == Team.TeamA)
        {
            CharacterTeam = characterTeam;
            CharacterMeshRenderer.material.color = Color.red;
        }
        else if (CharacterTeam == Team.TeamB)
        {
            CharacterTeam = characterTeam;
            CharacterMeshRenderer.material.color = Color.blue;
        }
    }

    #endregion

    public void MoveToPosition(Vector3 movePoint)
    {
        if (Runner.IsServer)
        {
            MovePoint = movePoint;
            OnMovePointChanged.Invoke();
            CharacterStateController.ChangeState(CharacterState.Walk);
        }
        else
        {
            RPC_RequestMove(movePoint);
        }
    }

    public void StartPathfind(Vector3 startPosition, Vector3 endPosition)
    {
       Seeker.StartPath(startPosition, endPosition);
    }

    public void CollectWoodSource(WoodSource woodSource)
    {
        if (Runner.IsServer)
        {
            WoodSource = woodSource;
            OnWoodSourceChanged.Invoke();
            CharacterStateController.ChangeState(CharacterState.MoveToCollect);
        }
        else
        {
            RPC_RequestWoodSourceCollect(woodSource.Object.Id);
        }
    }

    public void SetMovability(bool canMove)
    {
        AIPath.canMove = canMove;
    }

    [Rpc(sources: RpcSources.Proxies, targets: RpcTargets.StateAuthority)]
    public void RPC_RequestWoodSourceCollect(NetworkId id)
    {
        Debug.Log("RPC_RequestWoodSourceCollect");
        CollectWoodSource(Runner.FindObject(id).GetComponent<WoodSource>());
    }

    [Rpc(sources: RpcSources.Proxies, targets: RpcTargets.StateAuthority)]
    public void RPC_RequestMove(Vector3 movePoint)
    {
        Debug.Log("RPC_RequestMove");
        MoveToPosition(movePoint);
    }

}
