using DG.Tweening;
using UnityEngine.Events;
using UnityEngine;

/// <summary>
/// Manages interactive elements and button pressing animations.
/// </summary>
public class InteractiveSystem : MonoBehaviour
{
    /// <summary>
    /// Event triggered when an interaction is finished.
    /// </summary>
    public static UnityEvent onInteractionFinished;

    /// <summary>
    /// Animates the pressing of an interactive button.
    /// </summary>
    /// <param name="button">The InteractiveButton to be animated.</param>
    public static void AnimateButtonPressing(InteractiveButton button)
    {
        if (Time.timeScale == 0)
        {
            button.transform.DOScale(0.9f, 0.1f).SetUpdate(true).OnComplete(() =>
            {
                button.transform.DOScale(1f, 0.1f).SetUpdate(true).OnComplete(() =>
                {
                    button.onInteractionFinished.Invoke();
                });
            });

            return;
        }

        Sequence sequence = DOTween.Sequence();
        sequence.Append(button.transform.DOScale(0.9f, 0.1f));
        sequence.Append(button.transform.DOScale(1f, 0.1f));
        sequence.AppendCallback(() => button.onInteractionFinished.Invoke());
    }
}
