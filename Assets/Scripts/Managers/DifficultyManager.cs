using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour {

    public float timeToReachMaximumDifficulty;

    private float _timePassed;
    public float Difficulty { get; private set; } //só podem pegar a variável, não setar

    void Update() {
        IncreaseDifficultyOverTime();
    }

    void IncreaseDifficultyOverTime() {
        _timePassed += Time.deltaTime;
        Difficulty = _timePassed / timeToReachMaximumDifficulty;
        Difficulty = Mathf.Min(1, Difficulty);
        //pegamos um valor entre dois números e retornamos o menor
        //isso faz com que, assim que a difficulty for menos do que
        //1, ou seja, 100%, a dificuldade pare de aumentar.
    }
    
}
