using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject gameOverImage;
    public Text scoreTxt;

    private PlayerController _player;
    private int score;

    void Start() {
        _player = GameObject.FindObjectOfType<PlayerController>();
    }

    void DestroyObjects() {
        ObstacleBase[] obstacles = GameObject.FindObjectsOfType<ObstacleBase>();

        foreach(ObstacleBase obstacle in obstacles) {
            obstacle.DestroyImmediately();
        }
    }
    void ResetScore() {
        score = 0;
        scoreTxt.text = score.ToString();
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
        ResetScore();
    }
    public void AddScore() {
        score++;
        scoreTxt.text = score.ToString();
    }
   
}
