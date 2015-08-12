using System;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Scripts.Player {
    class PlayerSyncMouse : NetworkBehaviour {

        [SyncVar, SerializeField]
        private Vector3 _mousePosition;

        public Vector3 mousePosition {
            get {
                return isLocalPlayer ? GetLocalMousePosition() : _mousePosition;
            }
        }

        void FixedUpdate() {
            if (isLocalPlayer) {
                CmdSetMousePosition(GetLocalMousePosition());
            }
        }

        [Command]
        void CmdSetMousePosition(Vector3 value) {
            _mousePosition = value;
        }

        Vector3 GetLocalMousePosition() {
            return Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}
