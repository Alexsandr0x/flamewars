using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CrazyRotation : MonoBehaviour {
    public float cx = 0f;
    public float cy = 0.1f;
    public float cz = 0.01f;
    public float speed = 5f;
    float step = 0f;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        step += Time.deltaTime * speed;

        Quaternion q = transform.rotation;
        q.x = cx * Mathf.Sin(2 * step * Mathf.PI);
        q.y = cy * Mathf.Sin(2 * step * Mathf.PI);
        q.z = cz * Mathf.Sin(2 * step * Mathf.PI);

        transform.rotation = q;
    }
}
