using System;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Scripts.Player {
    class PlayerInput : NetworkBehaviour {

        public bool canAct = true;

        Rigidbody2D rigidBody;
        PlayerGroundSensor groundSensor;
        PlayerChat playerChat;
        [SerializeField]
        float speed = 100;

        private bool _canJump = true;
        private int jumpCount = 0;

        void Start() {
            rigidBody = GetComponent<Rigidbody2D>();
            groundSensor = GetComponent<PlayerGroundSensor>();
            playerChat = GetComponent<PlayerChat>();
        }

        void FixedUpdate() {
            if (!isLocalPlayer)
                return;

            if (canAct) {
                float hAxis = Input.GetAxis("Horizontal");

                Vector3 velocity = rigidBody.velocity;
                velocity.x = hAxis * speed;
                rigidBody.velocity = velocity;

                if (groundSensor.distance < 0.01f) {
                    jumpCount = 0;
                }
                if (Input.GetButtonDown("Jump") && CanJump()) {
                    Jump();
                }

                if (Input.GetAxisRaw("Chat") > 0) {
                    canAct = false;
                    playerChat.FocusOnInput();
                }
            } else {
                if (playerChat.focusedOnInput && (Input.GetAxisRaw("Submit") > 0 || Input.GetAxisRaw("Shoot") > 0)) {
                    playerChat.UnfocusOnInput();
                    canAct = true;
                }
            }
        }

        void Jump() {
            Vector2 velocity = rigidBody.velocity;
            velocity.y = 10;
            rigidBody.velocity = velocity;

            jumpCount++;
        }

        bool CanJump() {
            return jumpCount < 2;
        }
    }
}
