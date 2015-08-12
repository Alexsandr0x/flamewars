using System;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Player;

namespace Assets.Scripts {
    public class Team {
        public List<Player.Player> players = new List<Player.Player>();

        public static readonly Team[] list = {
            new Team("Blue", Color.blue), 
            new Team("Red", Color.red), 
            new Team("Green", Color.green)
        };

        public string name;
        public Color color;
        public int getTeamKills() {
            int kills = 0;
            foreach (var player in players)
                kills += player.kills;
            return kills;
        }

        public int getTeamDeaths()
        {
            int deaths = 0;
            foreach (var player in players)
                deaths += player.deaths;
            return deaths;
        }

        private Team(string name, Color color) {
            this.name = name;
            this.color = color;
        }
    }
}
