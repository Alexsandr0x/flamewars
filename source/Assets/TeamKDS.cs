using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Scripts;

public class TeamKDS : MonoBehaviour {

    Text blueKD, redKD, greenKD;

    void Start() {
        blueKD = GameObject.Find("BlueTeamKD").GetComponent<Text>();
        redKD = GameObject.Find("RedTeamKD").GetComponent<Text>();
        greenKD = GameObject.Find("GreenTeamKD").GetComponent<Text>();
    }

    void FixedUpdate() {
        blueKD.text = Team.list[0].getTeamKills() + "/" + Team.list[0].getTeamDeaths();
        redKD.text = Team.list[1].getTeamKills() + "/" + Team.list[1].getTeamDeaths();
        greenKD.text = Team.list[2].getTeamKills() + "/" + Team.list[2].getTeamDeaths();
    }
}