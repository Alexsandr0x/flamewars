using System;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Scripts.Player {
    class PlayerGunAimAtMouse : NetworkBehaviour {

        public bool fixedRadius = true;
        public float radius = 5f;

        [SerializeField]
        Transform target;
        [SerializeField]
        Transform shoulder;

        PlayerSyncMouse playerSyncMouse;

        void Start() {
            playerSyncMouse = GetComponent<PlayerSyncMouse>();
        }

        void Update() {
            Vector3 mousePosition = new Vector3(playerSyncMouse.mousePosition.x, playerSyncMouse.mousePosition.y, target.transform.position.z);
            if (fixedRadius) {
                var vec = (mousePosition - shoulder.position).normalized;
                vec.z = 0;
                target.position = shoulder.position + vec * radius;
            } else {
                target.position = mousePosition;
            }
        }

    }
}
