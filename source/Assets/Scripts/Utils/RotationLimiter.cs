using System;
using UnityEngine;

namespace Assets.Scripts.Utils {
    [ExecuteInEditMode]
    class RotationLimiter : MonoBehaviour {

        public float minAngle = 0;
        public float maxAngle = 360;

        public float currentAngle;
        public float newAngle;
        void Update() {
            currentAngle = transform.localRotation.eulerAngles.z;
            newAngle = ClampAngle(currentAngle, minAngle, maxAngle);

            transform.localRotation = Quaternion.EulerAngles(0, 0, newAngle * Mathf.Deg2Rad);   
        }
        float ClampAngle(float angle, float from, float to) {
            if (angle > 180)
                angle = 360 - angle;
            angle = Mathf.Clamp(angle, from, to);
            if (angle < 0)
                angle = 360 + angle;

            return angle;
        }
    }
}
