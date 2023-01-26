using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour {

    public Text scoreTxt;
    public Text hiScoreTxt;
    public AudioClip scoreSfx;

    private int _score;

    public void ResetScore() {
        _score = 0;
        scoreTxt.text = _score.ToString();
    }
    public void SaveHiScore() {
        int currentHiScore = PlayerPrefs.GetInt("hiscore");

        if(_score > currentHiScore) {
            PlayerPrefs.SetInt("hiscore", _score);
        }  
    }
    public void InterfaceUpdate() {
        int hiscore = PlayerPrefs.GetInt("hiscore");
        hiScoreTxt.text = hiscore.ToString();
    }
    public void AddScore() {
        _score++;
        scoreTxt.text = _score.ToString();
        AudioManager.instance.PlayOneShot(scoreSfx);
    }
    
}
