using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour {

    public float timeToReachMaximumDifficulty;

    private float _timePassed;
    private float _difficulty;

    void Update() {
        IncreaseDifficultyOverTime();
    }

    void IncreaseDifficultyOverTime() {
        _timePassed += Time.deltaTime;
        _difficulty = _timePassed / timeToReachMaximumDifficulty;
        _difficulty = Mathf.Min(1, _difficulty);
        //pegamos um valor entre dois números e retornamos o menor
        //isso faz com que, assim que a difficulty for menos do que
        //1, ou seja, 100%, a dificuldade pare de aumentar.
    }
    
}
