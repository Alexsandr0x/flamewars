using System;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Scripts.Player {
    class PlayerGroundSensor : NetworkBehaviour {

        [SerializeField]
        Transform foot;

        public RaycastHit2D raycastHit;
        public float distance;

        void Update() {
            if (!isLocalPlayer)
                return;

            raycastHit = Physics2D.Raycast(foot.position, Vector2.down, 10f);
            if (raycastHit.collider) {
                distance = raycastHit.distance;
            } else {
                distance = float.MaxValue;
            }
        }
    }
}
