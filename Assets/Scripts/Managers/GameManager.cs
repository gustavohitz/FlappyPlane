using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class GameManager : MonoBehaviour {

    private PlayerController _player;
    private GeneralUI _handUI;
    private ScoreUI _scoreUI;
    private GameOverUI _gameOverUI;
    private DifficultyManager _difficultyManager;

    void Start() {
        _player = GameObject.FindObjectOfType<PlayerController>();
        _handUI = GameObject.FindObjectOfType<GeneralUI>();
        _scoreUI = GameObject.FindObjectOfType<ScoreUI>();
        _gameOverUI = GameObject.FindObjectOfType<GameOverUI>();
        _difficultyManager = GameObject.FindObjectOfType<DifficultyManager>();
    }
    void Update() {
        LoadMainMenu();
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
        _difficultyManager.timePassed = 0;
        _gameOverUI.DeactivateGameOverPanel();
        _player.ResetPosition();
        DestroyObjects();
        _scoreUI.ResetScore();
        _handUI.ShowHandClicking();
    }
    public void LoadSinglePlayerGame() {
        SceneManager.LoadScene(1);
    }
    public void LoadMultiplayerGame() {
        SceneManager.LoadScene(2);
    }
    public void QuitGame() {
        Application.Quit();
    }

    private void LoadMainMenu() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
        }
    }
}
