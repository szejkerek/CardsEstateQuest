using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    public TextMeshProUGUI headerField;
    public TextMeshProUGUI contentField;
    public LayoutElement layout;
    public int characterWrap;
    public RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        Hide();
    }

    public void Show()
    {
        headerField.gameObject.SetActive(true);
        contentField.gameObject.SetActive(true);
    }

    public void Hide()
    {
        headerField.gameObject.SetActive(false);
        contentField.gameObject.SetActive(false);
    }

    public void SetText(string content, string header = "")
    {
        if(string.IsNullOrEmpty(header))
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
        int headerLenght = headerField.text.Length;
        int contentLenght = contentField.text.Length;

        layout.enabled = (headerLenght > characterWrap || contentLenght > characterWrap) ? true : false;
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
