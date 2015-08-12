using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BaconRain : MonoBehaviour {

    float step = 0;
    public float delay = 0.05f;
    public float minRotation = -300;
    public float maxRotation = -100;
    public GameObject baconPrefab;
	
	// Update is called once per frame
	void Update () {
        step += Time.deltaTime;
        if (step >= delay) {
            step = 0;
            CreateRandomBacon();
        }
	}

    void CreateRandomBacon() {
        var bacon = Instantiate(baconPrefab, Camera.main.ViewportToWorldPoint(new Vector3(Random.value, 1.1f, Camera.main.nearClipPlane)), Quaternion.identity) as GameObject;
        bacon.GetComponent<Rigidbody2D>().angularVelocity = Random.Range(minRotation, maxRotation);
        Destroy(bacon, 5);
    }
}
