using Fusion;
using UnityEngine;

public class Character : NetworkBehaviour
{
    [Networked(OnChanged = nameof(OnCharacterTeamChanged))]
    public Team CharacterTeam { get; set; }

    public MeshRenderer CharacterMeshRenderer;

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

}
