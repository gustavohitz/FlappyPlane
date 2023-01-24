using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float impulseForce = 10f;

    private Rigidbody2D _rb2d;

    void Awake() {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if(Input.GetButtonDown("Fire1")) {
            Impulse();
        }
    }

    void Impulse() {
        _rb2d.velocity = Vector2.zero;
        _rb2d.AddForce(Vector2.up * impulseForce, ForceMode2D.Impulse);
    }

}
