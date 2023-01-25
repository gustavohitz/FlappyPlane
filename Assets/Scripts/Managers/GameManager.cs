using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject gameOverImage;

    public void GameOver() {
        Time.timeScale = 0;
        gameOverImage.SetActive(true);
    }
   
}
