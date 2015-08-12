using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class SyncVelocity : NetworkBehaviour
{

    // Use this for initialization
    [SyncVar]
    Vector3 syncPosition;


    [SerializeField]
    float lerpRate = 15f;

    [SerializeField]
    Rigidbody2D body;

    [SerializeField]
    Transform transform;

    void Start()
    {
        NetworkServer.Spawn(this.gameObject);
        transform = GetComponent<Transform>();
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isServer)
            syncPosition = transform.position;
    }

    void LerpVelocity()
    {
        body.MovePosition(syncPosition);
    }
    void FixedUpdate()
    {
        if (!isServer)
            LerpVelocity();
    }
}
