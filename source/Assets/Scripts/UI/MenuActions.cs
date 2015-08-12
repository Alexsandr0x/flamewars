using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MenuActions : NetworkBehaviour {
    
    public InputField hostname;
    public InputField nickname;
    public Button team;

    public void StartHost() {
        NetworkLobbyManager.singleton.StartHost();
    }
    
    public void Join() {
        NetworkLobbyManager.singleton.networkAddress = hostname.text.Length > 0 ? hostname.text : "127.0.0.1";
        NetworkLobbyManager.singleton.StartClient();
    }

    public void StopConnection() {
        if (NetworkLobbyManager.singleton.isNetworkActive) {
            NetworkLobbyManager.singleton.StopHost();
        }
    }

    public void Exit() {
        Application.Quit();
    }
}
