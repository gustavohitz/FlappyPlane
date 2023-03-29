using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActivatePlayerThroughAnimation : MonoBehaviour {

    public UnityEvent OnFinishingInstructionPanelAnimation;

    public void ActivatePlayer() {
        OnFinishingInstructionPanelAnimation.Invoke();
    }
    
}
