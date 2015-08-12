using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Assets.Scripts;
using Assets.Scripts.Player;

public class LobbyPlayer : NetworkLobbyPlayer
{

    [SerializeField]
    public Player gamePlayer;

    [SyncVar]
    public int teamId;

    public Team team
    {
        get
        {
            return Team.list[teamId];
        }
    }

    [SyncVar]
    public string nickname;

    [SyncVar]
    public bool ready;

    private InputField nicknameInput;
    private Button readyButton;
    private Button teamButton;

    public override void OnClientEnterLobby()
    {
        base.OnClientEnterLobby();

        transform.SetParent(GameObject.Find("Players panel (lobby)").transform, false);
        transform.Find("In game").gameObject.SetActive(false);
        transform.Find("In lobby").gameObject.SetActive(true);
    }

    public override void OnStartLocalPlayer()
    {
        var lobbyMenu = GameObject.Find("Lobby menu").transform;

        nicknameInput = lobbyMenu.Find("Nickname").gameObject.GetComponent<InputField>();
        nicknameInput.onValueChange.RemoveAllListeners();
        nicknameInput.onValueChange.AddListener(OnNameChanged);

        readyButton = lobbyMenu.Find("Ready").gameObject.GetComponent<Button>();
        readyButton.onClick.RemoveAllListeners();
        readyButton.onClick.AddListener(OnReadyClicked);

        teamButton = lobbyMenu.Find("Team").gameObject.GetComponent<Button>();
        teamButton.onClick.RemoveAllListeners();
        teamButton.onClick.AddListener(ChangeTeam);
    }

    public void ChangeTeam()
    {
        teamId = (teamId + 1) % Team.list.Length;
        CmdSetTeam(teamId);
        ColorBlock colorBlock = teamButton.colors;
        colorBlock.normalColor = team.color;
        colorBlock.highlightedColor = team.color;

        teamButton.colors = colorBlock;
    }

    public void OnReadyClicked()
    {
        SendReadyToBeginMessage();
        CmdSetReady(true);
    }

    void OnNameChanged(string value)
    {
        CmdSetNickname(value);
    }

    [Command]
    void CmdSetNickname(string value)
    {
        value = (value.Length == 0) ? "anon" : value;
        nickname = value;
    }

    [Command]
    void CmdSetTeam(int value)
    {
        teamId = value;
    }

    [Command]
    void CmdSetReady(bool value)
    {
        ready = value;
    }
}
