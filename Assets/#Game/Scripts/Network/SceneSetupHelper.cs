using Fusion;
using UnityEngine;

public class SceneSetupHelper : MonoBehaviour
{
    NetworkRunner _networkRunner;
    public GameObject GameStateMachinePrefab;

    public void Setup(NetworkRunner runner)
    {
        _networkRunner = runner;
        if (runner.IsServer)
        {
            _networkRunner.Spawn(GameStateMachinePrefab);
        }
    }
}
