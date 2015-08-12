using System;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Networking;

namespace Assets.Scripts.UI {
    class LobbyPlayerTeamPin : MonoBehaviour {

        Image image;
        LobbyPlayer lobbyPlayer;

        void Start() {
            image = GetComponent<Image>();
            lobbyPlayer = GetComponentInParent<LobbyPlayer>();
        }
        void FixedUpdate() {
            image.color = lobbyPlayer.team.color;
        }
    }
}
