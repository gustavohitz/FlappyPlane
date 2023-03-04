using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerObstacleBase : MonoBehaviour {
    public FloatSharedVariable speed;

    [SerializeField]
    private float _variationYposition;
    private float _timeToDestroy = 9f;
    
    void Awake() {
        transform.Translate(Vector3.up * Random.Range(-_variationYposition, _variationYposition));
    }

    void Update() {
        transform.Translate(Vector3.left * speed.value * Time.deltaTime);
        DestroyObstacle();
    }

    void DestroyObstacle() {
        Destroy(gameObject, _timeToDestroy);
    }

    public void DestroyImmediately() {
        Destroy(gameObject);
    }
   
}
