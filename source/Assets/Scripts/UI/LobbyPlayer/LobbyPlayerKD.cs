using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Assets.Scripts.Networking;
using Assets.Scripts.Player;

namespace Assets.Scripts.UI {
    class LobbyPlayerKD : MonoBehaviour {

        Text text;
        Player.Player player;

        void Start() {
            text = GetComponent<Text>();
        }

        void FixedUpdate() {
            player = GetComponentInParent<LobbyPlayer>().gamePlayer;
            if (player) {
                text.text = player.kills + "/" + player.deaths;
            } else {
                text.text = "0/0";
            }
        }
    }
}
