using Fusion;
using UnityEngine;
using Pathfinding;
using UnityEngine.Events;

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

    public void MovePosition(Vector3 movePoint)
    {
        MovePoint = movePoint;
        OnMovePointChanged.Invoke();
        CharacterStateController.ChangeState(CharacterState.Walk);
    }

    public void CollectWoodSource(WoodSource woodSource)
    {
        WoodSource = woodSource;
        OnWoodSourceChanged.Invoke();
        CharacterStateController.ChangeState(CharacterState.MoveToCollect);
    }

    public void SetMovability(bool canMove)
    {
        AIPath.canMove = canMove;
    }

}
