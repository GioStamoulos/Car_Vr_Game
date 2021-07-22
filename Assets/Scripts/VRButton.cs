using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;

[Serializable]
public class VRButtonEvent : UnityEvent { }

public class VRButton : MonoBehaviour
{
    public VRButtonEvent delayedEvent = new VRButtonEvent();

    public float interactionDelay = 3;

    public void PointerEnter()
    {
        StartCoroutine(WaitToInterract());
    }


    public IEnumerator WaitToInterract()
    {
        yield return new WaitForSeconds(interactionDelay);

        Debug.Log("Action Triggered.");

        delayedEvent.Invoke();
    }


}
