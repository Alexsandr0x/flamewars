using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Assets.Scripts.Player;

public class LifeBar : MonoBehaviour {

    CameraScript camera;
    RectTransform lifeBar;
    Player player;

    // Use this for initialization
    void Start() {
        camera = GameObject.Find("Main Camera").GetComponent<CameraScript>();
    }
    // Update is called once per frame
    void Update() {
        if (camera.target) {
            player = camera.target.GetComponentInParent<Player>();
            if (player) {
                lifeBar = GetComponent<RectTransform>();
                float targetScale = player.gameObject.GetComponent<PlayerHealth>().health / 100f;
                targetScale = Mathf.Clamp01(targetScale);
                float currentScale = lifeBar.localScale.x;
                float newScale = Mathf.Lerp(currentScale, targetScale, 0.5f);

                lifeBar.localScale = new Vector2(newScale, 1);
            }
        }
    }
}