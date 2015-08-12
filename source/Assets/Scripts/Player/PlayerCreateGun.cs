using System;
using UnityEngine;
using UnityEngine.Networking;
using Assets.Scripts.Gun;

namespace Assets.Scripts.Player {
    class PlayerCreateGun : NetworkBehaviour {

        [SerializeField]
        GameObject gunBone;
        [SerializeField]
        GameObject gunFrefab;

        void Start() {
            GameObject gun = Instantiate(gunFrefab, Vector3.zero, Quaternion.identity) as GameObject;
            gun.GetComponent<GunScript>().owner = gameObject;

            Transform leftGrip = gun.transform.Find("Left grip");
            Transform rightGrip = gun.transform.Find("Right grip");
            Transform muzzle = gun.transform.Find("Muzzle");
            Transform pivot = gun.transform.Find("Pivot");

            Transform leftHand = transform.Find("Helpers").Find("Helper - Left hand");
            Transform rightHand = transform.Find("Helpers").Find("Helper - Right hand");

            gun.transform.parent = gunBone.transform;
            gun.transform.localPosition = pivot.localPosition;
            gun.transform.localRotation = Quaternion.EulerAngles(0, 0, Mathf.PI * 0.5f);

            gunBone.GetComponent<Bone>().length = Vector3.Distance(pivot.position, muzzle.position);

            leftHand.GetComponent<StickyPosition>().target = leftGrip;
            rightHand.GetComponent<StickyPosition>().target = rightGrip;

            GetComponent<Player>().gun = gun;
        }

    }
}
