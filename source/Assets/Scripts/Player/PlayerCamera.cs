using System;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Scripts.Player {
    class PlayerCamera : NetworkBehaviour {

        void Start() {
            if (isLocalPlayer) {
                Camera.main.GetComponent<CameraScript>().target = transform;
            }
        }

    }
}
