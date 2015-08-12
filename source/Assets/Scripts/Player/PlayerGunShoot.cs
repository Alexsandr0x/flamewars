using System;
using UnityEngine;
using UnityEngine.Networking;
using Assets.Scripts.Gun;

namespace Assets.Scripts.Player {
    class PlayerGunShoot : NetworkBehaviour {

        GunScript gunScript;

        void Update() {
            if (!gunScript && GetComponent<Player>().gun) {
                gunScript = GetComponent<Player>().gun.GetComponent<GunScript>();
            }

            if (isLocalPlayer && Input.GetAxis("Shoot") > 0 && GetComponent<PlayerInput>().canAct) {
                Shoot();
            }
        }

        public void Shoot() {
            Vector2 muzzlePos = gunScript.GetMuzzlePosition();
            float angle = gunScript.GetAngle();
            Vector2 playerVelocity = gunScript.GetPlayerVelocity();
            angle += UnityEngine.Random.Range(-gunScript.precision, gunScript.precision);

            CmdShoot(muzzlePos, angle, playerVelocity);
            if (isServer) {
                gunScript.Shoot(muzzlePos, angle, playerVelocity);
            }
        }

        [Command]
        public void CmdShoot(Vector3 position, float angle, Vector2 playerVelocity) {
            RpcShoot(position, angle, playerVelocity);
        }

        [ClientRpc]
        public void RpcShoot(Vector3 position, float angle, Vector2 playerVelocity) {
            gunScript.Shoot(position, angle, playerVelocity);
        }
    }
}
