using System;
using UnityEngine;

namespace Assets.Scripts.Gun {
    class AimRenderer : MonoBehaviour {
        public float angle = 0;
        public int pieces = 4;
        public float length = 10;
        public float innerRadius = 3;
        public Vector2 position;
        public Color color = Color.white;

        [SerializeField]
        Texture texture;

        void Start() {
            Cursor.visible = false;
        }

        void OnGUI() {
            if (Cursor.visible)
                return;

            position = Input.mousePosition;
            position = new Vector2(position.x, Screen.height - position.y);
            if (Event.current.type.Equals(EventType.Repaint)) {
                Matrix4x4 matrixBackup = GUI.matrix;
                float dAngle = (Mathf.PI * 2) / pieces;
                GUI.color = color;
                for (int i = 0; i < pieces; i++) {
                    GUI.matrix = Matrix4x4.TRS(position, Quaternion.EulerAngles(0, 0, angle + dAngle * i), Vector3.one);
                    GUI.DrawTexture(new Rect(0, 0 + innerRadius, 1, length), texture);
                }
                GUI.matrix = matrixBackup;
            }
        }
    }
}
