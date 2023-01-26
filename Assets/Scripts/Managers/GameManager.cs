using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject gameOverImage;
    public Text scoreTxt;
    public Text hiScoreTxt;
    public AudioClip scoreSfx;

    private PlayerController _player;
    private HandAnimationController _handAnimation;
    private int _score;

    void Start() {
        _player = GameObject.FindObjectOfType<PlayerController>();
        _handAnimation = GameObject.FindObjectOfType<HandAnimationController>();
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
    void SaveHiScore() {
        int currentHiScore = PlayerPrefs.GetInt("hiscore");

        if(_score > currentHiScore) {
            PlayerPrefs.SetInt("hiscore", _score);
        }  
    }
    void InterfaceUpdate() {
        int hiscore = PlayerPrefs.GetInt("hiscore");
        hiScoreTxt.text = hiscore.ToString();
    }

    public void GameOver() {
        Time.timeScale = 0;
        gameOverImage.SetActive(true);
        SaveHiScore();
        InterfaceUpdate();
    }
    public void RestartGame() {
        Time.timeScale = 1;
        gameOverImage.SetActive(false);
        _player.ResetPosition();
        DestroyObjects();
        ResetScore();
        _handAnimation.ShowHandClicking();
    }
    public void AddScore() {
        _score++;
        scoreTxt.text = _score.ToString();
        AudioManager.instance.PlayOneShot(scoreSfx);
    }
   
}
