using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Represents an interactive button with animation on press.
/// </summary>
public class InteractiveButton : Button
{
    /// <summary>
    /// Event triggered when the interaction is finished.
    /// </summary>
    [SerializeField]
    public UnityEvent onInteractionFinished;

    protected override void Start()
    {
        base.Start();

        onClick.AddListener(AnimateButtonPressing);
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();

        onClick.RemoveListener(AnimateButtonPressing);
    }

    private void AnimateButtonPressing()
    {
        if (interactable)
        {
            InteractiveSystem.AnimateButtonPressing(this);
        }
    }
}
