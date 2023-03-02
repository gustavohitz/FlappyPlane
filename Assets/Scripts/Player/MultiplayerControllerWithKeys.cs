using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MultiplayerControllerWithKeys : MonoBehaviour {

    [SerializeField]
    private KeyCode _keyToFly;

    public UnityEvent OnGettingKeyDown;


    void Update() {
        if(Input.GetKeyDown(_keyToFly) && Time.timeScale == 1) {
            OnGettingKeyDown.Invoke();
        }
    }
    
}
