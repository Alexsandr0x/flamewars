using System;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Scripts.Player {

    class PlayerFace : NetworkBehaviour {

        [SerializeField]
        SpriteRenderer headRenderer;

        Player player;
        PlayerHealth playerHealth;

        [SyncVar(hook="UpdateFace")]
        public string faceName;

        void Start() {
            player = GetComponent<Player>();
            playerHealth = GetComponent<PlayerHealth>();
        }

        void FixedUpdate() {
            if (isLocalPlayer) {
                float health = playerHealth.health;

                Face face = Face.defaultFace;
                foreach (var faceCandidate in Face.list) {
                    if (faceCandidate.verify(gameObject) && faceCandidate.priority > face.priority) {
                        face = faceCandidate;
                    }
                }
                if (faceName != face.spriteName) {
                    CmdSetFace(face.spriteName);
                }
            }
        }

        [Command]
        void CmdSetFace(string value) {
            faceName = value;
        }

        void UpdateFace(string value) {
            faceName = value;

            var sprite = Resources.Load<Sprite>("Sprites/Faces/" + faceName);
            headRenderer.sprite = sprite;
        }

    }
}
