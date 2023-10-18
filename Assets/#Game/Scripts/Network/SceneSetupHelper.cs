using Fusion;
using UnityEngine;

public class SceneSetupHelper : MonoBehaviour
{
    NetworkRunner _networkRunner;
    public GameObject GameStateMachinePrefab;

    public void Setup(NetworkRunner runner)
    {
        _networkRunner = runner;
    }
    void Start()
    {
        _networkRunner.Spawn(GameStateMachinePrefab);
    }
}
