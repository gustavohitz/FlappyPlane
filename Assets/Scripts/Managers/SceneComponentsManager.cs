using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneComponentsManager : MonoBehaviour {

    private MultiplayerBackgroundBase _multiplayerBackground;
    private MultiplayerGroundBase _multiplayerGround;
    private ObstacleGenerator _obstacleGenerator;


    void Start() {
        _multiplayerBackground = GetComponentInChildren<MultiplayerBackgroundBase>();
        _multiplayerGround = GetComponentInChildren<MultiplayerGroundBase>();

        _obstacleGenerator = GetComponentInChildren<ObstacleGenerator>();
    }

    public void DeactivateSceneElements() {
        _multiplayerBackground.enabled = false;
        _multiplayerGround.enabled = false;

        _obstacleGenerator.Stop();
    }

}
