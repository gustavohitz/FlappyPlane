using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class MultiplayerGameManager : MonoBehaviour {

    private MultiplayerController _multiplayerController;
    private GeneralUI _handUI;
    private ScoreUI _scoreUI;
    private GameOverUI _gameOverUI;
    private DifficultyManager _difficultyManager;

    void Start() {
        _multiplayerController = GameObject.FindObjectOfType<MultiplayerController>();
        _handUI = GameObject.FindObjectOfType<GeneralUI>();
        _scoreUI = GameObject.FindObjectOfType<ScoreUI>();
        _gameOverUI = GameObject.FindObjectOfType<GameOverUI>();
        _difficultyManager = GameObject.FindObjectOfType<DifficultyManager>();
    }

    void DestroyObjects() {
        MultiplayerObstacleBase[] obstacles = GameObject.FindObjectsOfType<MultiplayerObstacleBase>();

        foreach(MultiplayerObstacleBase obstacle in obstacles) {
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
        _difficultyManager.timePassed = 0;
        _gameOverUI.DeactivateGameOverPanel();
        _multiplayerController.ResetPosition();
        DestroyObjects();
        _scoreUI.ResetScore();
        _handUI.ShowHandClicking();
    }
    public void LoadSinglePlayerGame() {
        SceneManager.LoadScene(1);
    }
}
