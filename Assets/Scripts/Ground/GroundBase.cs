using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBase : MonoBehaviour {

    [SerializeField]
    private float _speed;
    private Vector3 _initialPosition;
    private float _realImageSize;

    void Awake() {
        _initialPosition = transform.position;
        float imageSize = GetComponent<SpriteRenderer>().size.x;
        float scale = transform.localScale.x;
        _realImageSize = imageSize * scale;
    }

    void Update() {
        float moving = Mathf.Repeat(_speed * Time.time, _realImageSize);
        transform.position = _initialPosition + Vector3.left * moving;
    }
    
}