using UnityEngine;

public class DestroyOnTime : MonoBehaviour {

    [SerializeField]
    public float lifeTime = 2f;

    void Update() {
        if (lifeTime > 0) {
            lifeTime -= Time.deltaTime;
        } else {
            Destroy(gameObject);
        }
    }
}
