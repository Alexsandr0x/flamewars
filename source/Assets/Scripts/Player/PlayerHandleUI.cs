using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;
using Assets.Scripts.Player;

public class PlayerHandleUI : NetworkBehaviour {
    GameObject lifeBar;
    GameObject canvas;

    public float speed = 1f;

    void Start()
    {
        canvas = GameObject.Find("Canvas").gameObject;
        lifeBar = canvas.transform.Find("Life Bar").gameObject;
    }

    void Update() {
        if (!isLocalPlayer)
            return;

        var rectTransform = lifeBar.GetComponent<RectTransform>();
        float targetScale = GetComponent<PlayerHealth>().health / 100f;
        targetScale = Mathf.Clamp01(targetScale);
        float currentScale = rectTransform.localScale.x;
        float newScale = Mathf.Lerp(currentScale, targetScale, 0.5f);

        lifeBar.GetComponent<RectTransform>().localScale = new Vector2(newScale, 1);
	}
}
