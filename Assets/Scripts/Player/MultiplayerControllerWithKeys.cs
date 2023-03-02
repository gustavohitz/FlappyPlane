using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerControllerWithKeys : MonoBehaviour {

    [SerializeField]
    private KeyCode _keyToFly;
    private MultiplayerController _multiplayerController;

    void Start(){
        _multiplayerController = GetComponent<MultiplayerController>();
    }

    void Update() {
        if(Input.GetKeyDown(_keyToFly) && Time.timeScale == 1) {
            _multiplayerController.Impulse();
        }
    }
    
}
