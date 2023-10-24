using Fusion;
using Fusion.Sockets;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PhotonManager : MonoBehaviour, INetworkRunnerCallbacks
{
    public int PlayerLevel = 1;

    [SerializeField]
    NetworkRunner _runner;

    [SerializeField]
    GameObject setupPrefab;
    [SerializeField]
    GameObject networkGameManagerPrefab;
    [SerializeField]
    GameObject gameManagerPrefab;

    [HideInInspector]
    public UnityEvent OnPlayersReady = new();

    public static PhotonManager Instance { get; private set; }

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

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

        if (runner.ActivePlayers.Count() == 2)
        {
            StartCoroutine(SetupGame(runner, player));
            OnPlayersReady.Invoke();
        }
    }

    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {
        //Finish Game
        CloseConnection();

        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            SceneManager.LoadScene(0);
        }
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

    public async void StartGame()
    {
        _runner.ProvideInput = true;

        var customProps = new Dictionary<string, SessionProperty>
        {
            ["level"] = PlayerLevel
        };

        await _runner.StartGame(new StartGameArgs()
        {
            GameMode = GameMode.AutoHostOrClient,
            SessionProperties = customProps,
            Scene = 1,
            SceneManager = gameObject.AddComponent<NetworkSceneManagerDefault>(),
            PlayerCount = 2,

        });
    }

    public void CloseConnection()
    {
        _runner.Shutdown();
    }

    public IEnumerator SetupGame(NetworkRunner runner, PlayerRef player)
    {
        /*
            var setupPrefabObject = Instantiate(setupPrefab);
            var sceneSetupHelper = setupPrefabObject.GetComponent<SceneSetupHelper>();
            sceneSetupHelper.Setup(runner);
        */

        if (runner.IsServer)
        {
            var networkGameManager = runner.Spawn(networkGameManagerPrefab);
        }

        yield return new WaitForSeconds(3);


        if (runner.IsServer)
        {
            runner.Spawn(gameManagerPrefab);
        }

        //SceneManager.LoadScene("GameScene");
    }
}
