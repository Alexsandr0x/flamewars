using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;
using Assets.Scripts.Player;

public class PlayerNameLabel : NetworkBehaviour {

    LobbyPlayer lobbyPlayer;
    TextMesh textMesh;
    void Start() {
        lobbyPlayer = GetComponentInParent<Player>().lobbyPlayer;
        textMesh = GetComponent<TextMesh>();
    }
    void FixedUpdate() {
        textMesh.text = lobbyPlayer.nickname;
        textMesh.color = lobbyPlayer.team.color;
    }

    void Update() {
        transform.rotation = Quaternion.identity;
    }
}
