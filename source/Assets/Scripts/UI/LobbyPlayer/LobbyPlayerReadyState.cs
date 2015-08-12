using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Assets.Scripts.Networking;

namespace Assets.Scripts.UI {
    class LobbyPlayerReadyState : MonoBehaviour {

        Text text;
        LobbyPlayer lobbyPlayer;

        void Start() {
            text = GetComponent<Text>();
            lobbyPlayer = GetComponentInParent<LobbyPlayer>();
        }
        void FixedUpdate() {
            text.text = lobbyPlayer.ready ? "ready" : "";
        }
    }
}
