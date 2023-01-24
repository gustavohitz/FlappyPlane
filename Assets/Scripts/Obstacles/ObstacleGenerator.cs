using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour {
   
    [SerializeField]
    private float _timeToGenerate;
    [SerializeField]
    private GameObject _obstaclePrefab;
    private float _timer;

    void Awake() {
        _timer = _timeToGenerate;
    }

    void Update() {
        _timer -= Time.deltaTime;

        if(_timer <= 0) {
            CreateObstacle();
        }
    }

    void CreateObstacle() {
        Instantiate(_obstaclePrefab, transform.position, Quaternion.identity);
        _timer = _timeToGenerate;
    }

}
