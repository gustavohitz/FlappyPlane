using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralUI : MonoBehaviour {
    [SerializeField]
    private GameObject _handImage;

    void Awake() {
        //_handImage = GetComponent<SpriteRenderer>();
    }

    void Update() {
        HideAfterClicking();
    }

    void HideAfterClicking() {
        if(Input.GetButtonDown("Fire1")) {
            _handImage.SetActive(false);
        }
    }

    public void ShowHandClicking() {
        _handImage.SetActive(true);
    }
    
}
