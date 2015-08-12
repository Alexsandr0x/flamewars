using UnityEngine;
using System.Collections;

public class SoundOnShoot : MonoBehaviour {

    AudioClip gunshot;
    AudioSource source;
	void OnShoot () {
        gunshot = Resources.Load<AudioClip>("Sounds/gunfire");
        source = GetComponent<AudioSource>();

        source.PlayOneShot(gunshot);
	}
}
