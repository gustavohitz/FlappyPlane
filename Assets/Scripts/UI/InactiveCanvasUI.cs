using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InactiveCanvasUI : MonoBehaviour {

    public GameObject background;
    public Canvas canvas;
    public Text text;

    void Awake() {
        canvas = GetComponent<Canvas>();
    }

    public void ShowUI(Camera camera) {
        background.SetActive(true);
        canvas.worldCamera = camera;
    }

    public void HideUI() {
        background.SetActive(false);
    }

    public void UpdateText(int pointsToRevive) {
        text.text = pointsToRevive.ToString();
    }

 
}
