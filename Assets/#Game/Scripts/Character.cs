using Fusion;
using UnityEngine;
using Pathfinding;

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

    public override void Spawned()
    {
        ChangeCharacterTeam(CharacterTeam);
    }

    public void MovePosition(Vector3 movePoint)
    {
        MovePoint = movePoint;
        CharacterStateController.ChangeState(CharacterState.Walk);
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

}
