using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
class GoThroughPlatformFromBottom : MonoBehaviour {

    [SerializeField]
    GameObject collider;

    void OnTriggerEnter2D(Collider2D other) {
        GameObject root = other.gameObject.transform.root.gameObject;
        Physics2D.IgnoreCollision(other, collider.GetComponent<Collider2D>(), true);
    }

    void OnTriggerExit2D(Collider2D other) {
        Physics2D.IgnoreCollision(other, collider.GetComponent<Collider2D>(), false);
    }

}
