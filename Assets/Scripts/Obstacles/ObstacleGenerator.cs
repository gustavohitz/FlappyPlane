using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour {
   
    [SerializeField]
    private float _timeToGenerateOnEasyDifficulty;
    [SerializeField]
    private float _timeToGenerateOnHardDifficulty;
    [SerializeField]
    private GameObject _obstaclePrefab;
    private float _timer;
    private DifficultyManager _difficultyManager;
    private bool _stop;

    void Awake() {
        _timer = _timeToGenerateOnEasyDifficulty;
    }
    void Start() {
        _difficultyManager = GameObject.FindObjectOfType<DifficultyManager>();
    }

    void Update() {
        if(_stop) {
            return;
        }

        _timer -= Time.deltaTime;

        if(_timer <= 0) {
            CreateObstacle();
        }
    }

    void CreateObstacle() {
        Instantiate(_obstaclePrefab, transform.position, Quaternion.identity);
        _timer = Mathf.Lerp(_timeToGenerateOnEasyDifficulty, _timeToGenerateOnHardDifficulty, _difficultyManager.Difficulty);
        /* Assim, é gerado um tempo entre a dificuldade fácil e 
        a difícil de acordo com a dificuldade do jogo*/
    }

    public void Stop() {
        _stop = true;
    }

    public void Restart() {
        _stop = false;
    }

}
