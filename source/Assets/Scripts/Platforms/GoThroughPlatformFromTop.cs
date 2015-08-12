using System;
using UnityEngine;
using Assets.Scripts.Player;

[RequireComponent(typeof(BoxCollider2D))]
class GoThroughPlatformFromTop : MonoBehaviour {

    [SerializeField]
    GameObject collider;

    bool playerOnTrigger;
    Collider2D playerCollider;

    void Update() {
        if (playerOnTrigger && Input.GetKey(KeyCode.S)) {
            Physics2D.IgnoreCollision(playerCollider, collider.GetComponent<Collider2D>(), true);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (IsPlayer(other)) {
            playerOnTrigger = true;
            playerCollider = other;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (IsPlayer(other)) {
            playerOnTrigger = false;
            playerCollider = null;
            Physics2D.IgnoreCollision(other, collider.GetComponent<Collider2D>(), false);
        }
    }

    bool IsPlayer(Collider2D other) {
        return other.gameObject.GetComponentInParent<Player>();
    }
}
