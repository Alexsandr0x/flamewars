using System;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Scripts.Player {
    class PlayerAnimator : NetworkBehaviour {

        PlayerGroundSensor playerGroundSensor;
        PlayerFlip playerFlip;
        Rigidbody2D rigidBody;
        Animator animator;

        void Start() {
            playerGroundSensor = GetComponent<PlayerGroundSensor>();
            playerFlip = GetComponent<PlayerFlip>();
            rigidBody = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }

        void Update() {
            animator.SetFloat("Horizontal speed", Mathf.Abs(rigidBody.velocity.x));
            animator.SetFloat("Vertical speed", Mathf.Abs(rigidBody.velocity.y));
            animator.SetBool("Is falling", rigidBody.velocity.y < 0);
            animator.SetFloat("Orientation", playerFlip.orientation * rigidBody.velocity.x);
            animator.SetFloat("Distance to ground", playerGroundSensor.distance);
        }

    }
}
