using UnityEngine;
using System.Collections;

public class DetachPaticlesOnDeath : MonoBehaviour {

    private GameObject particle;
	void Start () {
        particle = transform.Find("Particles").gameObject;
        Debug.Log(particle);
	}

    void OnDisable() {

        particle.transform.position = this.transform.position;

        var particles = particle.gameObject.GetComponentsInChildren(typeof(ParticleSystem), true);

        foreach (ParticleSystem par in particles){
            par.transform.parent = null;
            par.emissionRate = 0f;
            Destroy(par.gameObject,5f);
        }
    }
}
