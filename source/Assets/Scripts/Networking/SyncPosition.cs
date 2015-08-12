using System;
using UnityEngine;
using UnityEngine.Networking;
using Assets.Scripts.Utils;

namespace Assets.Scripts.Networking {
    class SyncPosition : NetworkBehaviour {
        [SerializeField]
        Transform _transform;

        [SerializeField]
        float lerpRate = 15f;

        [SyncVar]
        Vector3 syncPosition;

        private bool isLocal;

        void Start() {
            isLocal = NetworkUtils.RatinhosTest(gameObject);
        }

        void FixedUpdate() {
            LerpPosition();
            TransmitPosition();
        }

        void LerpPosition() {
            if (!isLocal) {
                _transform.position = Vector3.Lerp(_transform.position, syncPosition, Time.deltaTime * lerpRate);
            }
        }

        [Command]
        void CmdProvidePositionToServer(Vector3 value) {
            syncPosition = value;
        }

        [Client]
        void TransmitPosition() {
            if (isLocal) {
                CmdProvidePositionToServer(_transform.position);
            }
        }
    }
}
