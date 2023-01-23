using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float impulseForce = 10f;
    private Rigidbody2D rb2d;

    void Awake() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if(Input.GetButtonDown("Fire1")) {
            Impulse();
        }
    }

    void Impulse() {
        rb2d.AddForce(Vector2.up * impulseForce, ForceMode2D.Impulse);
    }

}
