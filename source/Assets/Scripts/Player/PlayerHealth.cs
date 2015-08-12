using System;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Scripts.Player {
    class PlayerHealth : NetworkBehaviour {

        public const float MAX_HEALTH = 100f;

        [SyncVar, SerializeField]
        public float health = MAX_HEALTH;

        public void ReceiveDamage(Player shooter, float value) {
            if (isLocalPlayer) {
                health -= value;
                CmdSetHealth(health);
                if (health <= 0) {
                    GetComponent<Player>().AddDeath(shooter.netId);
                    Die();
                    Camera.main.GetComponent<CameraScript>().target = shooter.transform;
                }
            }
        }

        [Command]
        public void CmdSetHealth(float value) {
            health = value;
        }

        public void Die() {
            SetActive(false);
            Invoke("ReSpawn", 5);
        }

        public void ReSpawn() {
            SetActive(true);
            var playerScript = GetComponent<Player>();
            var lobbyPlayer = playerScript.lobbyPlayer;

            GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint " + lobbyPlayer.team.name);

            transform.position = spawnPoints[0].transform.position;

            CmdSetHealth(MAX_HEALTH);

            Camera.main.GetComponent<CameraScript>().target = transform;


        }
        void SetActive(bool value) {
            CmdSetActive(value);
            if (isServer) {
                gameObject.SetActive(value);
            }
        }


        [Command]
        void CmdSetActive(bool value) {
            RpcSetActive(value);
        }

        [ClientRpc]
        void RpcSetActive(bool value) {
            gameObject.SetActive(value);
        }
    }
}