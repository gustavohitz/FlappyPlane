using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ScoreUI : MonoBehaviour {

    public Text scoreTxt;
    public Text hiScoreTxt;
    public Text gameOverScoreTxt;
    public AudioClip scoreSfx;
    public UnityEvent OnScoring;

    private int _score;
    private int _hiScore;
    [SerializeField]
    private Image _rewardMedal;
    [SerializeField]
    private Sprite _goldMedal;
    [SerializeField]
    private Sprite _silverMedal;
    [SerializeField]
    private Sprite _bronzeMedal;

    public void ResetScore() {
        _score = 0;
        scoreTxt.text = _score.ToString();
        gameOverScoreTxt.text = _score.ToString();
    }
    public void SaveHiScore() {
        int currentHiScore = PlayerPrefs.GetInt("hiscore");

        if(_score > currentHiScore) {
            PlayerPrefs.SetInt("hiscore", _score);
        }  
    }
    public void InterfaceUpdate() {
        _hiScore = PlayerPrefs.GetInt("hiscore");
        hiScoreTxt.text = _hiScore.ToString();

        CheckRewardMedal();
    }
    public void AddScore() {
        _score++;
        scoreTxt.text = _score.ToString();
        gameOverScoreTxt.text = _score.ToString();
        OnScoring.Invoke();
    }

    void CheckRewardMedal() {
        if(_score > _hiScore - 2) {
            _rewardMedal.sprite = _goldMedal;
        }
        else if(_score > _hiScore / 2) {
            _rewardMedal.sprite = _silverMedal;
        }
        else {
            _rewardMedal.sprite = _bronzeMedal;
        }
    }
    public void PlayScoreSound() {
        AudioManager.instance.PlayOneShot(scoreSfx);
    }
    
}
