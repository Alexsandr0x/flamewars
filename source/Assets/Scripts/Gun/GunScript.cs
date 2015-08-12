using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using Assets.Scripts.Player;

namespace Assets.Scripts.Gun {
    public class GunScript : NetworkBehaviour {
        [SerializeField]
        public GameObject owner;

        [SerializeField]
        public float bulletSpeed = 30;

        [SerializeField]
        public float precision = 0.01f;

        [SerializeField]
        public float fireRate = 10f;
        float fireTimer = 0;

        public GameObject bulletPrefab;

        Transform leftGrip;
        Transform rightGrip;
        Transform muzzle;
        Transform capsuleExit;

        void Start() {
            leftGrip = transform.Find("Left grip");
            rightGrip = transform.Find("Right grip");
            muzzle = transform.Find("Muzzle");
            capsuleExit = transform.Find("Capsule exit");
        }

        public void Shoot() {
            Shoot(GetMuzzlePosition(), GetAngle(), GetPlayerVelocity());
        }

        void Update() {
            if (fireTimer < 0)
                fireTimer = 0;
            if (fireTimer > 0)
                fireTimer -= Time.deltaTime;
        }

        public void Shoot(Vector3 muzzlePosition, float angle, Vector2 playerVelocity) {
            if (fireTimer > 0)
                return;

            fireTimer = 1/fireRate;

            SendMessageUpwards("OnShoot", owner);

            GameObject newBullet = (GameObject)Instantiate(bulletPrefab, muzzlePosition, Quaternion.AngleAxis(angle * Mathf.Rad2Deg, new Vector3(0, 0, 1)));

            newBullet.GetComponent<BulletScript>().owner = owner;

            Rigidbody2D bulletRigidBody = newBullet.GetComponent<Rigidbody2D>();

            //bulletRigidBody.velocity = playerVelocity + new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * bulletSpeed;
            bulletRigidBody.velocity = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * bulletSpeed;

            if (bulletRigidBody.velocity.x < 0) {
                var localScale = newBullet.transform.localScale;
                localScale.y *= -1;
                newBullet.transform.localScale = localScale;
            }
        }

        public Vector3 GetMuzzlePosition() {
            return muzzle.position;
        }

        public float GetAngle() {
            float angle = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
            if (owner.GetComponent<PlayerFlip>().orientation == -1) {
                angle = Mathf.PI - angle;
            }
            return angle;
        }

        public Vector2 GetPlayerVelocity() {
            return owner.GetComponent<Rigidbody2D>().velocity;
        }
    }
}
