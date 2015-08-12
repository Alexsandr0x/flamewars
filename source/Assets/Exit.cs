using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {

    [SerializeField]
    GameObject exitPanel;

	void Start () {
        exitPanel.SetActive(false);
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)){
            exitPanel.SetActive(!exitPanel.activeInHierarchy);
            Cursor.visible = exitPanel.activeInHierarchy;
        }
	}


    public void ConfirmExit() {
        Application.Quit();
    }

    public void Cancel() {
        exitPanel.SetActive(!exitPanel.activeInHierarchy);
        Cursor.visible = false;
    }
}
