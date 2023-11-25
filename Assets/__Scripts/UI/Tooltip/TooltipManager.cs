using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the display and hiding of tooltips in the game.
/// </summary>
public class TooltipManager : Singleton<TooltipManager>
{
    /// <summary>
    /// The Tooltip component used to display information.
    /// </summary>
    public Tooltip tooltip;

    /// <summary>
    /// The delay before showing the tooltip when triggered.
    /// </summary>
    public float delay = 0.5f;

    private Coroutine showCoroutine;

    /// <summary>
    /// Shows a tooltip with the specified content and optional header.
    /// </summary>
    /// <param name="content">The content text for the tooltip.</param>
    /// <param name="header">The optional header text for the tooltip.</param>
    public void Show(string content, string header = "")
    {
        showCoroutine = StartCoroutine(ShowWithDelay(content, header));
    }

    /// <summary>
    /// Hides the currently displayed tooltip.
    /// </summary>
    public void Hide()
    {
        if (showCoroutine != null)
        {
            StopCoroutine(showCoroutine);
        }
        tooltip.Hide();
    }

    private IEnumerator ShowWithDelay(string content, string header)
    {
        yield return new WaitForSeconds(delay);
        tooltip.SetText(content, header);
        tooltip.Show();
    }
}
