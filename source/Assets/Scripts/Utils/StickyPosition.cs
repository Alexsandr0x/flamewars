using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class StickyPosition : MonoBehaviour {

    [SerializeField]
    public Transform target;

	void LateUpdate () {
        if (target) {
            //transform.position = target.position;
            transform.position = Vector3.Lerp(transform.position, target.position, 0.5f);
        }
	}
}
