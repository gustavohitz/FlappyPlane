using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour {

    public float impulseForce;
    public UnityEvent OnCollidingPlane;

    private Rigidbody2D _rb2d;
    private Vector3 _initialPosition;
    private bool _useImpulse;
    private Animator _animator;

    void Awake() {
        _animator = GetComponent<Animator>();
        _rb2d = GetComponent<Rigidbody2D>();
        _initialPosition = transform.position;
    }


    void Update() {
        if(Input.GetButtonDown("Fire1") && Time.timeScale == 1) {
            _useImpulse = true;
        }

        _animator.SetFloat("speedY", _rb2d.velocity.y);
    }
    void FixedUpdate() {
        if(_useImpulse) {
            Impulse();
        }
    }

    public void Impulse() {
        _rb2d.velocity = Vector2.zero;
        _rb2d.AddForce(Vector2.up * impulseForce, ForceMode2D.Impulse);
        _useImpulse = false;
    }

    void OnCollisionEnter2D(Collision2D other) {
        _rb2d.simulated = false;
        OnCollidingPlane.Invoke();
    }

    public void ResetPosition() {
        _rb2d.simulated = true;
        transform.position = _initialPosition;
    }
}
