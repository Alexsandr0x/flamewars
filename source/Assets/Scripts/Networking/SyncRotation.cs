using System;
using UnityEngine;
using UnityEngine.Networking;
using Assets.Scripts.Utils;

namespace Assets.Scripts.Networking {
    class SyncRotation : NetworkBehaviour {
        [SerializeField]
        Transform _transform;

        [SerializeField]
        float lerpRate = 15f;

        [SyncVar]
        Quaternion syncRotation;

        private bool isLocal;

        void Start() {
            isLocal = NetworkUtils.RatinhosTest(gameObject);
        }

        void FixedUpdate() {
            LerpRotation();
            TransmitRotation();
        }

        void LerpRotation() {
            if (!isLocal) {
                _transform.rotation = Quaternion.Lerp(_transform.rotation, syncRotation, Time.deltaTime * lerpRate);
            }
        }

        [Command]
        void CmdProvideRotationToServer(Quaternion value) {
            syncRotation = value;
        }

        [Client]
        void TransmitRotation() {
            if (isLocal) {
                CmdProvideRotationToServer(_transform.rotation);
            }
        }
    }
}
