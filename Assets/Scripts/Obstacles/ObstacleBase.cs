using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBase : MonoBehaviour {

    public float speed = .3f;

    [SerializeField]
    private float _variationYposition;

    void Awake() {
        transform.Translate(Vector3.up * Random.Range(-_variationYposition, _variationYposition));
    }

    void Update() {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
   
}
