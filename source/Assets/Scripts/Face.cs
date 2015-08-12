using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class Face
    {

        public static readonly Face[] list = new Face[]{ 
                                               new Face("Focused", (x) => {
                                                    return true;
                                               }, -1),
                                               new Face("Rage", (x) => {
                                                   return x.GetComponent<Player.PlayerHealth>().health <= 40;
                                               }, 100),
                                               new Face("Super rage", (x) => {
                                                   return x.GetComponent<Player.PlayerHealth>().health <= 10;
                                               }, 200),
                                               new Face("Trollface", (x) => {
                                                   var player = x.GetComponent<Player.Player>();
                                                   return player.kills - player.deaths >= 3;
                                               }, 10),
                                               new Face("Fuck yea", (x) => {
                                                   var player = x.GetComponent<Player.Player>();
                                                   return player.kills - player.deaths >= 5;
                                               }, 20),
                                               new Face("Vish", (x) => {
                                                   var player = x.GetComponent<Player.Player>();
                                                   return player.deaths - player.kills >= 3;
                                               }, 10),
                                               new Face("NO.", (x) => {
                                                   var player = x.GetComponent<Player.Player>();
                                                   return player.deaths - player.kills >= 5;
                                               }, 20),
                                               new Face("Okay", (x) => {
                                                   var player = x.GetComponent<Player.Player>();
                                                   return player.deaths - player.kills >= 8;
                                               }, 30)
                                             };
        public static readonly Face defaultFace = list[0];

        public delegate bool del(GameObject playerObject);

        public string spriteName;
        public del verify;
        public int priority;

        public Face(string spriteName, del verify, int priority)
        {
            this.spriteName = spriteName;
            this.verify = verify;
            this.priority = priority;
        }
    }
}
