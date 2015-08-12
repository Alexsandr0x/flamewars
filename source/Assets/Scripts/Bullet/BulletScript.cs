using UnityEngine;
using Assets.Scripts.Player;
using Assets.Scripts.Utils;

public class BulletScript : MonoBehaviour {

    public GameObject owner;
    public int damage = 15;

    void OnTriggerEnter2D(Collider2D other) {
        if (!other.transform.IsChildOf(owner.gameObject.transform)) {
            if (other.gameObject.GetComponentInParent<Player>()) {

                var otherGameObject = other.transform.root.gameObject;

                if (NetworkUtils.IsSameTeam(owner, otherGameObject))
                    return;

                other.gameObject.GetComponentInParent<PlayerHealth>().ReceiveDamage(owner.GetComponent<Player>(), damage);
            }
            Destroy(gameObject);
        }
    }
}
