using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI {
    class PlayerList : MonoBehaviour {
        void FixedUpdate() {

            var position = transform.localPosition;
            if(Input.GetKey(KeyCode.Tab)) {
                position.z = 0;
            } else {
                position.z = -10000;
            }

            transform.localPosition = position;
        }
    }
}
