using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class NetworkManagerScript : MonoBehaviour {

	void Start () {
		NetworkManager netManager = GetComponent<NetworkManager> ();
		var prefabs = Resources.LoadAll ("Prefabs/Spawnables", typeof(GameObject));
		foreach (var item in prefabs) {
			netManager.spawnPrefabs.Add(item as GameObject);
		}
	}
}
