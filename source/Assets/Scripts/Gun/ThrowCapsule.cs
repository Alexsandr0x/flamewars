using System;
using UnityEngine;

namespace Assets.Scripts.Gun {
    class ThrowCapsule : MonoBehaviour {

        public GameObject capsulePrefab;
        Transform pivot;

        public float horizontalRandomnessMin = -1f;
        public float horizontalRandomnessMax = 1f;
        public float verticalRandomnessMin = 2f;
        public float verticalRandomnessMax = 4f;

        void Start(){
            pivot = transform.Find("Barrel");
        }

        void OnShoot(GameObject shooter) {
            var capsule = Instantiate(capsulePrefab, pivot.position, pivot.rotation) as GameObject;
            var rigidBody = capsule.GetComponent<Rigidbody2D>();

            rigidBody.velocity = new Vector2(
                UnityEngine.Random.Range(horizontalRandomnessMin, horizontalRandomnessMax),
                UnityEngine.Random.Range(verticalRandomnessMin, verticalRandomnessMax));
        }
    }
}
