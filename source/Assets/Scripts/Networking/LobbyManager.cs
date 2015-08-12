using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using Assets.Scripts.Player;

public class LobbyManager : NetworkLobbyManager {

    public override bool OnLobbyServerSceneLoadedForPlayer(GameObject lobbyPlayer, GameObject gamePlayer) {

        Application.runInBackground = true;

        LobbyPlayer sLobbyPlayer = lobbyPlayer.GetComponent<LobbyPlayer>();

        Player sPlayer = gamePlayer.GetComponent<Player>();

        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint " + sLobbyPlayer.team.name);

        int rnd = Random.Range(0, spawnPoints.Length);
        sPlayer.transform.position = spawnPoints[rnd].transform.position;
        sPlayer.lobbyPlayerId = sLobbyPlayer.netId.Value;
        
        return true;
    }
}
