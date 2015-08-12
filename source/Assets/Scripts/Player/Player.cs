using System;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Scripts.Player {
    public class Player : NetworkBehaviour {

        bool isOnTeam = false;

        [SyncVar]
        public int kills;
        [SyncVar]
        public int deaths;

        [SyncVar]
        public uint lobbyPlayerId;
        [SerializeField]
        private LobbyPlayer _lobbyPlayer;

        public LobbyPlayer lobbyPlayer {
            get {
                if (!_lobbyPlayer) {
                    var identities = GameObject.FindObjectsOfType<NetworkIdentity>();
                    foreach (var candidate in identities) {
                        if (candidate.netId.Value == lobbyPlayerId) {
                            _lobbyPlayer = candidate.gameObject.GetComponent<LobbyPlayer>();
                            _lobbyPlayer.gamePlayer = this;
                            break;
                        }
                    }
                }
                return _lobbyPlayer;
            }
        }

        public GameObject gun;

        void Update() {
            if (!isOnTeam) {
                lobbyPlayer.team.players.Add(this);
                isOnTeam = true;
            }
        }

        void Start() {

            if (isLocalPlayer)
                GetComponent<AudioListener>().enabled = true;

            var lobbyPlayers = GameObject.FindObjectsOfType<LobbyPlayer>();
            foreach (var player in lobbyPlayers) {
                player.transform.SetParent(GameObject.Find("Players panel (game)").transform, false);

                player.transform.Find("In game").gameObject.SetActive(true);
                player.transform.Find("In lobby").gameObject.SetActive(false);
            }
            GameObject.Find("LobbyManager").transform.Find("Canvas").gameObject.SetActive(false);
        }
        
        public void AddDeath(NetworkInstanceId attacker) {
            CmdAddDeath(attacker);
        }

        [Command]
        public void CmdAddDeath(NetworkInstanceId attacker) {
            deaths++;
            var attackerObj = ClientScene.FindLocalObject(attacker);
            if (attackerObj) {
                attackerObj.GetComponent<Player>().kills++;
            }
        }
    }
}
