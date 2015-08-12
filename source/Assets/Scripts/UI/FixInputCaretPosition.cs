using System;
using UnityEngine;
using UnityEngine.UI;
namespace Assets.Scripts.UI {
    class FixInputCaretPosition : MonoBehaviour {
        [SerializeField]
        Vector2 offset;

        [SerializeField]
        RectTransform text;
        void Update() {
            if(GetComponentInChildren<LayoutElement>())
                text.pivot = offset;
        }
    }
}
