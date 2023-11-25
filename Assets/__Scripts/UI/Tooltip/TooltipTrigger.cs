using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Represents a tooltip trigger for displaying information when hovering over an object.
/// </summary>
public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    /// <summary>
    /// The header text for the tooltip.
    /// </summary>
    [SerializeField] private string header;

    /// <summary>
    /// The content text for the tooltip.
    /// </summary>
    [SerializeField, TextArea(3, 1)] private string content;

    /// <summary>
    /// Called when the pointer enters the object's area.
    /// Shows the tooltip with the specified content and header.
    /// </summary>
    /// <param name="eventData">The event data associated with the pointer enter event.</param>
    public void OnPointerEnter(PointerEventData eventData)
    {
        TooltipManager.Instance.Show(content, header);
    }

    /// <summary>
    /// Called when the pointer exits the object's area.
    /// Hides the tooltip.
    /// </summary>
    /// <param name="eventData">The event data associated with the pointer exit event.</param>
    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipManager.Instance.Hide();
    }
}
