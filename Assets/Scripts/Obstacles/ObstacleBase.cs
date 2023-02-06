using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBase : MonoBehaviour {

    public FloatSharedVariable speed;

    [SerializeField]
    private float _variationYposition;
    private float _timeToDestroy = 9f;
    private Vector3 _playerPosition;
    private bool _hasScored;
    private ScoreUI _scoreUI;

    void Awake() {
        transform.Translate(Vector3.up * Random.Range(-_variationYposition, _variationYposition));
    }

    void Start() {
        _playerPosition = GameObject.FindObjectOfType<PlayerController>().transform.position;
        _scoreUI = GameObject.FindObjectOfType<ScoreUI>();
    }

    void Update() {
        transform.Translate(Vector3.left * speed.value * Time.deltaTime);
        DestroyObstacle();
        AddOnePoint();
    }

    void DestroyObstacle() {
        Destroy(gameObject, _timeToDestroy);
    }
    void AddOnePoint() {
        if(!_hasScored && transform.position.x < _playerPosition.x) {
            _hasScored = true;
            _scoreUI.AddScore();
        }
    }

    public void DestroyImmediately() {
        Destroy(gameObject);
    }
   
}
