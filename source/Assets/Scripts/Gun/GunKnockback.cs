using System;
using UnityEngine;
namespace Assets.Scripts.Gun {
    class GunKnockback : MonoBehaviour {
        [SerializeField]
        float maxAngle = 100;

        [SerializeField]
        float strength = 1;

        [SerializeField]
        float recoverySpeed = 1;

        void OnShoot(GameObject owner) {
            float angle = GetAngle() + strength;
            SetAngle(angle);
        }

        void Update() {
            float angle = GetAngle() - recoverySpeed * Time.deltaTime;
            SetAngle(Mathf.Clamp(angle, 90, maxAngle));
        }

        float GetAngle() {
            return transform.localRotation.eulerAngles.z;
        }

        void SetAngle(float angle) {
            transform.localRotation = Quaternion.EulerAngles(0, 0, angle * Mathf.Deg2Rad);
        }
    }
}
