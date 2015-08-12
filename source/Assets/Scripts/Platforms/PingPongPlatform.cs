using UnityEngine;
using System.Collections;

public class PingPongPlatform : MonoBehaviour {

    float range = 1;

    [SerializeField]
    Transform point;

    Vector3 initPos;

    Vector3 endPos;

    Vector3 dir;

    Rigidbody2D body;

    [SerializeField]
    float speed = 1;

    void Start() {
        initPos = transform.position;
        endPos = point.position;

        body = GetComponent<Rigidbody2D>();
        dir = (endPos - initPos);
    }


    void FixedUpdate() {

        if ((initPos - transform.position).magnitude < range) {
            body.velocity = dir.normalized * speed;
        } else if ((endPos - transform.position).magnitude < range) {
            body.velocity = -dir.normalized * speed;
        }
    }
}