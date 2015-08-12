using System;

using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Player {
    public class PlayerChat : NetworkBehaviour {

        public bool focusedOnInput = false;
        public Text chatText;
        public InputField chatInput;

        PlayerInput playerInput;

        void Start() {
            chatText = GameObject.Find("Chat text").GetComponent<Text>();
            chatInput = GameObject.Find("Chat input").GetComponent<InputField>();

            playerInput = GetComponent<PlayerInput>();
        }

        public void FocusOnInput() {
            chatInput.gameObject.SetActive(true);
            SetZ(0);
            chatInput.ActivateInputField();

            focusedOnInput = true;
        }

        public void UnfocusOnInput() {
            chatInput.gameObject.SetActive(false);
            SetZ(-10000);
            chatInput.DeactivateInputField();

            focusedOnInput = false;
        }

        void OnGUI() {
            if (isLocalPlayer && Input.GetAxisRaw("Submit") > 0) {
                if (chatInput.text != "") {
                    SendMessage(chatInput.text.Replace("<","&#60;").Replace(">","&#62;"));
                }
                chatInput.text = "";
                SetZ(-10000);
                chatInput.gameObject.SetActive(false);
            }
        }

        void SendMessage(string message) {
            message = "<color=" + GetComponent<Player>().lobbyPlayer.team.name + ">" + GetComponent<Player>().lobbyPlayer.nickname + ": </color>" + message;
            CmdSendMessage(message);
            if (isServer) {
                chatText.text += "\n" + message;
            }
        }

        [Command]
        void CmdSendMessage(string message) {
            RpcReceiveMessage(message);
        }

        [ClientRpc]
        void RpcReceiveMessage(string message) {
            chatText.text += "\n" + message;
        }

        void SetZ(float value) {
            var pos = chatInput.transform.localPosition;
            pos.z = value;
            chatInput.transform.localPosition = pos;
        }
    }
}