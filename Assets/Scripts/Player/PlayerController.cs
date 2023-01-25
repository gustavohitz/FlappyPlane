using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float impulseForce;

    private Rigidbody2D _rb2d;
    private GameManager _gameManager;

    void Awake() {
        _rb2d = GetComponent<Rigidbody2D>();
        _gameManager = GameObject.FindObjectOfType<GameManager>();
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

    void OnCollisionEnter2D(Collision2D other) {
        _rb2d.simulated = false;
        _gameManager.GameOver();
    }

}
