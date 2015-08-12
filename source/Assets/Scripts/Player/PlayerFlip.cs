using System;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Scripts.Player {
    class PlayerFlip : NetworkBehaviour {

        PlayerSyncMouse playerSyncMouse;

        public float orientation = 1;

        void Start() {
            playerSyncMouse = GetComponent<PlayerSyncMouse>();
        }

        void Update() {
            orientation = Mathf.Sign(playerSyncMouse.mousePosition.x - transform.position.x);
            float angle = (1 - orientation) * 0.5f * Mathf.PI;
            transform.localRotation = Quaternion.EulerAngles(0, angle, 0);
        }

    }
}
