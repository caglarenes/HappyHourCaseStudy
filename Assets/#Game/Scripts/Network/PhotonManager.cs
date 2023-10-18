using Fusion;
using Fusion.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhotonManager : MonoBehaviour, INetworkRunnerCallbacks
{
    [SerializeField]
    NetworkRunner _runner;

    [SerializeField]
    GameObject setupPrefab;

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void OnConnectedToServer(NetworkRunner runner)
    {
        
    }

    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
    {
        
    }

    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
    {
        
    }

    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
    {
        
    }

    public void OnDisconnectedFromServer(NetworkRunner runner)
    {
        
    }

    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
    {
        
    }

    public void OnInput(NetworkRunner runner, NetworkInput input)
    {
        
    }

    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
    {
        
    }

    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        Debug.Log($"Player Joined. Player ID: {player.PlayerId}");

        if (runner.ActivePlayers.Count() == 1)
        {
            var setupPrefabObject = Instantiate(setupPrefab);
            var sceneSetupHelper = setupPrefabObject.GetComponent<SceneSetupHelper>();
            sceneSetupHelper.Setup(runner);
            //SceneManager.LoadScene("GameScene");
        }
    }

    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {
        //End Game
    }

    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data)
    {
        
    }

    public void OnSceneLoadDone(NetworkRunner runner)
    {
        
    }

    public void OnSceneLoadStart(NetworkRunner runner)
    {
        
    }

    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
    {
        
    }

    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
    {
        Debug.Log($"Network Runned shut down. Reason: {shutdownReason}");
    }

    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
    {
        
    }

    void Start()
    {
        StartGame(GameMode.AutoHostOrClient);
    }

    async void StartGame(GameMode mode)
    {
        _runner.ProvideInput = true;

        await _runner.StartGame(new StartGameArgs()
        {
            GameMode = mode,
            SessionName = "TestRoom",
            Scene = SceneManager.GetSceneByName("GameScene").buildIndex,
            SceneManager = gameObject.AddComponent<NetworkSceneManagerDefault>(),
            PlayerCount = 2,   
        });
    }
}
