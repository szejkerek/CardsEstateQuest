using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string header;
    [TextArea(3, 1)] public string content;

    private void OnMouseEnter()
    {
        TooltipManager.Instance.Show(content, header);
    }

    private void OnMouseExit()
    {
        TooltipManager.Instance.Hide();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        TooltipManager.Instance.Show(content, header);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipManager.Instance.Hide();
    }
}