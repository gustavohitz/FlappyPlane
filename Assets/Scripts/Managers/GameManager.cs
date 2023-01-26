using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    private PlayerController _player;
    private GeneralUI _handUI;
    private ScoreUI _scoreUI;
    private GameOverUI _gameOverUI;

    void Start() {
        _player = GameObject.FindObjectOfType<PlayerController>();
        _handUI = GameObject.FindObjectOfType<GeneralUI>();
        _scoreUI = GameObject.FindObjectOfType<ScoreUI>();
        _gameOverUI = GameObject.FindObjectOfType<GameOverUI>();
    }

    void DestroyObjects() {
        ObstacleBase[] obstacles = GameObject.FindObjectsOfType<ObstacleBase>();

        foreach(ObstacleBase obstacle in obstacles) {
            obstacle.DestroyImmediately();
        }
    }

    public void GameOver() {
        Time.timeScale = 0;
        _gameOverUI.ActivateGameOverPanel();
        _scoreUI.SaveHiScore();
        _scoreUI.InterfaceUpdate();
    }
    public void RestartGame() {
        Time.timeScale = 1;
        _gameOverUI.DeactivateGameOverPanel();
        _player.ResetPosition();
        DestroyObjects();
        _scoreUI.ResetScore();
        _handUI.ShowHandClicking();
    }
}
