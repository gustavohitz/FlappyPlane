using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class MultiplayerGameManager : MonoBehaviour {

    private GeneralUI _handUI;
    private ScoreUI _scoreUI;
    private GameOverUI _gameOverUI;
    private DifficultyManager _difficultyManager;
    private SceneComponentsManager[] _sceneComponents;
    private MultiplayerController[] _multiplayerController;
    private bool _OnePlayerIsDead;
    private bool _becomeParent;
    private int _scoreSinceDeath;
    private InactiveCanvasUI _inactiveInterface;

    public int amountOfPointsToRevive;

    void Start() {
        _handUI = GameObject.FindObjectOfType<GeneralUI>();
        _scoreUI = GameObject.FindObjectOfType<ScoreUI>();
        _gameOverUI = GameObject.FindObjectOfType<GameOverUI>();
        _difficultyManager = GameObject.FindObjectOfType<DifficultyManager>();
        _sceneComponents = GameObject.FindObjectsOfType<SceneComponentsManager>();
        _multiplayerController = GameObject.FindObjectsOfType<MultiplayerController>();
        _inactiveInterface = GameObject.FindObjectOfType<InactiveCanvasUI>();
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
        _OnePlayerIsDead = false;
        Time.timeScale = 1;
        _difficultyManager.timePassed = 0;
        _gameOverUI.DeactivateGameOverPanel();
        DestroyObjects();
        _scoreUI.ResetScore();
        _handUI.ShowHandClicking();
        RevivePlayer();
    }
    public void LoadSinglePlayerGame() {
        SceneManager.LoadScene(1);
    }

    public void OnePlayerIsDeadWarning(Camera camera) {
        if(_OnePlayerIsDead) {
            _inactiveInterface.HideUI();
            GameOver();
        }
        else {
            _OnePlayerIsDead = true;
            _scoreSinceDeath = 0;
            _inactiveInterface.UpdateText(amountOfPointsToRevive);
            _inactiveInterface.ShowUI(camera);
        }
    }

    public void ReviveIfNecessary() {
        if(_OnePlayerIsDead) {
            _scoreSinceDeath++;
            _inactiveInterface.UpdateText(amountOfPointsToRevive - _scoreSinceDeath);
            if(_scoreSinceDeath >= amountOfPointsToRevive) {
                _OnePlayerIsDead = false;
                _inactiveInterface.HideUI();
                RevivePlayer();
            }
        }
    }

    void RevivePlayer() {
        foreach(var sceneComponents in _sceneComponents) {
            sceneComponents.ActivateSceneElements();
        }

        foreach(var multiplayerController in _multiplayerController) {
            if(multiplayerController.isCrashed == true) {
                multiplayerController.ResetPosition();
            }
        }
    }
}    
