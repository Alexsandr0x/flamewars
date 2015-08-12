using UnityEngine;
using UnityEngine.UI;

public class SuperRainbow : MonoBehaviour {

    public float speed = 1f;
    float step = 0;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        step += Time.deltaTime * speed;
        if (step > 1)
            step = 0;

        GetComponent<Text>().color = new HSBColor(step, 1, 1, 1).ToColor();
    }
}
