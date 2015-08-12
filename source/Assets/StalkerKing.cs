using UnityEngine;
using System.Collections;

public class StalkerKing : MonoBehaviour {

    Transform player;
    CameraScript camera;
    Transform kingFace;
	void Start () {
        camera = GameObject.Find("Main Camera").GetComponent<CameraScript>();
        kingFace = GameObject.Find("King").GetComponent<Transform>();
	}
	
	void Update () {
        if (camera.target){
            player = camera.target;

            if (player.position.x > kingFace.position.x)
                kingFace.gameObject.SetActive(true);
            else kingFace.gameObject.SetActive(false);
        }
	}
}
