using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float impulseForce;

    private Rigidbody2D _rb2d;
    private GameManager _gameManager;
    private Vector3 _initialPosition;
    private bool _useImpulse;

    void Awake() {
        _rb2d = GetComponent<Rigidbody2D>();
        _initialPosition = transform.position;
    }

    void Start() {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void Update() {
        if(Input.GetButtonDown("Fire1")) {
            _useImpulse = true;
        }
    }
    void FixedUpdate() {
        if(_useImpulse) {
            Impulse();
        }
    }

    void Impulse() {
        _rb2d.velocity = Vector2.zero;
        _rb2d.AddForce(Vector2.up * impulseForce, ForceMode2D.Impulse);
        _useImpulse = false;
    }

    void OnCollisionEnter2D(Collision2D other) {
        _rb2d.simulated = false;
        _gameManager.GameOver();
    }

    public void ResetPosition() {
        _rb2d.simulated = true;
        transform.position = _initialPosition;
    }
}
