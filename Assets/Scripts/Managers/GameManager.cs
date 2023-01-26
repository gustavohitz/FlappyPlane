using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject gameOverImage;
    public Text scoreTxt;
    public AudioClip scoreSfx;

    private PlayerController _player;
    private int _score;

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
        _score = 0;
        scoreTxt.text = _score.ToString();
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
        _score++;
        scoreTxt.text = _score.ToString();
        AudioManager.instance.PlayOneShot(scoreSfx);
    }
   
}
