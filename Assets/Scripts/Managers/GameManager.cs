using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject gameOverImage;

    private PlayerController _player;

    void Start() {
        _player = GameObject.FindObjectOfType<PlayerController>();
    }

    void DestroyObjects() {
        ObstacleBase[] obstacles = GameObject.FindObjectsOfType<ObstacleBase>();

        foreach(ObstacleBase obstacle in obstacles) {
            obstacle.DestroyImmediately();
        }
    }

    public void GameOver() {
        Time.timeScale = 0;
        gameOverImage.SetActive(true);
    }
    public void RestartGame() {
        Time.timeScale = 1;
        gameOverImage.SetActive(false);
        _player.ResetPosition();
        DestroyObjects();
    }
   
}
