using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CpuController : MonoBehaviour {

    private MultiplayerController _cpuController;

    void Start() {
        _cpuController = GetComponent<MultiplayerController>();
        StartCoroutine(CpuImpulse());
    }

    IEnumerator CpuImpulse() {
        while(true) {
            yield return new WaitForSeconds(0.5f);
            _cpuController.Impulse();
        }
    }
   
}
