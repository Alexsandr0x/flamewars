using System;
using UnityEngine;
using UnityEngine.Networking;
using Assets.Scripts.Player;

namespace Assets.Scripts.Utils {
    class NetworkUtils {
        public static bool RatinhosTest(GameObject gameObject) {
            while (true) {
                if (gameObject.GetComponent<NetworkBehaviour>().isLocalPlayer) return true;
                if (gameObject.transform.parent) {
                    gameObject = gameObject.transform.parent.gameObject;
                } else {
                    return false;
                }
            }
        }

        public static bool IsSameTeam(GameObject pl1, GameObject pl2){

            var myTeam = pl1.GetComponent<Player.Player>().lobbyPlayer.team;
            var otherTeam = pl2.GetComponent<Player.Player>().lobbyPlayer.team;

            return otherTeam == myTeam;
        }
    }
}
