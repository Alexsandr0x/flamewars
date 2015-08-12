using UnityEngine;
using System.Collections;

public class DettachMeow : MonoBehaviour {

    GameObject meow;
	void Start () {
        meow = transform.Find("Audio Source").gameObject;
	}
	
    void OnDisable() {
        meow.transform.parent = null;
        Destroy(meow, 1f);
    } 
}
