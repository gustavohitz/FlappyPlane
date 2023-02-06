using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerBackgroundBase : MonoBehaviour {

    [SerializeField]
    private FloatSharedVariable _speed;
    private Vector3 _initialPosition;
    private float _realImageSize;

    void Awake() {
        _initialPosition = transform.position;
        float imageSize = GetComponent<SpriteRenderer>().size.x;
        float scale = transform.localScale.x;
        _realImageSize = imageSize * scale;
    }

    void Update() {
        float moving = Mathf.Repeat(_speed.value * Time.time, _realImageSize / 2);
        transform.position = _initialPosition + Vector3.left * moving;
    }
   
}
