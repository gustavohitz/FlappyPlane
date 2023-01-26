using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAnimationController : MonoBehaviour {

    private SpriteRenderer _handImage;

    void Awake() {
        _handImage = GetComponent<SpriteRenderer>();
    }

    void Update() {
        HideAfterClicking();
    }

    void HideAfterClicking() {
        if(Input.GetButtonDown("Fire1")) {
            _handImage.enabled = false;
        }
    }

    public void ShowHandClicking() {
        _handImage.enabled = true;
    }

}
