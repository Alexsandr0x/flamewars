using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class LinearSortingLayers : MonoBehaviour {

    //[SerializeField] SpriteRenderer headSprite;
    private static int nextLayer = 1;

    void Start() {
        foreach (var renderer in GetComponentsInChildren<SpriteRenderer>()) {
            renderer.sortingOrder = nextLayer;
        }
        //headSprite.sortingOrder = nextLayer + 1;
        nextLayer++;
    }   
}
