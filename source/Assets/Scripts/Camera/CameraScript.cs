using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{

	public Transform target;
	public float maxSize = 10;
	public float minSize = 2;
	public float scrollSpeed = 0.1f;

	void Update ()
	{
		if (target) {
			Camera cam = GetComponent<Camera> ();

			float cameraSize = cam.orthographicSize - Input.GetAxis ("Mouse ScrollWheel") * scrollSpeed;
			cameraSize = Mathf.Clamp (cameraSize, minSize, maxSize);
			Vector3 targetNoZ = new Vector3 (target.position.x, target.position.y, transform.position.z);
            transform.position = targetNoZ;
			//cam.orthographicSize = cameraSize;
		}
	}
}
