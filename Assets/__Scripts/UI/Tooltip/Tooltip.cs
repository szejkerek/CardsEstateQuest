using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the display and positioning of tooltips.
/// </summary>
public class Tooltip : MonoBehaviour
{
    /// <summary>
    /// The TextMeshProUGUI component for the tooltip's header.
    /// </summary>
    public TextMeshProUGUI headerField;

    /// <summary>
    /// The TextMeshProUGUI component for the tooltip's content.
    /// </summary>
    public TextMeshProUGUI contentField;

    /// <summary>
    /// The LayoutElement component for the tooltip's layout.
    /// </summary>
    public LayoutElement layout;

    /// <summary>
    /// The character wrap length for the tooltip.
    /// </summary>
    public int characterWrap;

    /// <summary>
    /// The RectTransform component for the tooltip's position.
    /// </summary>
    public RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        Hide();
    }

    /// <summary>
    /// Displays the tooltip by enabling the header and content.
    /// </summary>
    public void Show()
    {
        headerField.gameObject.SetActive(true);
        contentField.gameObject.SetActive(true);
    }

    /// <summary>
    /// Hides the tooltip by disabling the header and content.
    /// </summary>
    public void Hide()
    {
        headerField.gameObject.SetActive(false);
        contentField.gameObject.SetActive(false);
    }

    /// <summary>
    /// Sets the content and optional header for the tooltip.
    /// </summary>
    /// <param name="content">The content text for the tooltip.</param>
    /// <param name="header">The optional header text for the tooltip.</param>
    public void SetText(string content, string header = "")
    {
        if (string.IsNullOrEmpty(header))
        {
            headerField.gameObject.SetActive(false);
        }
        else
        {
            headerField.gameObject.SetActive(true);
            headerField.text = header;
        }
        contentField.text = content;

        SetSize();
    }

    private void SetSize()
    {
        int headerLength = headerField.text.Length;
        int contentLength = contentField.text.Length;

        layout.enabled = (headerLength > characterWrap || contentLength > characterWrap) ? true : false;
    }

    Vector2 velocity = Vector2.zero;
    private void Update()
    {
        Vector2 position = Input.mousePosition;
        Vector2 pivot = Vector2.zero;

        float screenWidth = Screen.width;
        float screenHeight = Screen.height;
        float threshold = 0.1f;

        if (position.x < screenWidth * 0.5f)
        {
            pivot.x = 0f;
        }
        else
        {
            pivot.x = 1f;
        }

        if (position.y < screenHeight * 0.5f)
        {
            pivot.y = 0f;
        }
        else
        {
            pivot.y = 1f;
        }

        rectTransform.pivot = pivot + new Vector2(pivot.x * threshold, pivot.y * threshold);
        Vector2 targetPosition = position;
        transform.position = Vector2.SmoothDamp(transform.position, targetPosition, ref velocity, 0.1f);
    }
}
