using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour {

    public GameObject gameOverImage;


    public void ActivateGameOverPanel() {
        gameOverImage.SetActive(true);
    }
    public void DeactivateGameOverPanel() {
        gameOverImage.SetActive(false);
    }
   
}
