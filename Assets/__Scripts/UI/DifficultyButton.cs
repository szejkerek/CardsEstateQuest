using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// Represents a difficulty selection button in the game.
/// </summary>
public class DifficultyButton : MonoBehaviour
{
    /// <summary>
    /// The alpha value when the button is deselected.
    /// </summary>
    [SerializeField, Range(0f, 1f)] float deselectedAlpha;

    /// <summary>
    /// The TextMeshProUGUI component for the button's title.
    /// </summary>
    [SerializeField] TextMeshProUGUI title;

    /// <summary>
    /// The Image component for the button's icon.
    /// </summary>
    [SerializeField] Image image;

    /// <summary>
    /// Gets the difficulty associated with this button.
    /// </summary>
    public IDifficulty Difficulty => difficulty;

    IDifficulty difficulty;
    CanvasGroup alphaChanger;
    RectTransform buttonTransform;

    private void Awake()
    {
        alphaChanger = GetComponent<CanvasGroup>();
        buttonTransform = GetComponent<RectTransform>();

        // Add a click event listener to the button.
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        // Handle the button click by notifying the DifficultyButtonsController.
        DifficultyButtonsController.Instance.ManageSelectedButton(this);
    }

    /// <summary>
    /// Sets the difficulty for this button and updates its title and icon.
    /// </summary>
    /// <param name="difficulty">The difficulty to set for this button.</param>
    public void SetDifficulty(IDifficulty difficulty)
    {
        this.difficulty = difficulty;
        SetTitle(difficulty.Name);
        SetIcon(difficulty.Icon);
    }

    void SetTitle(string text)
    {
        title.text = text;
    }

    void SetIcon(Sprite icon)
    {
        image.sprite = icon;
    }

    /// <summary>
    /// Selects the button by adjusting its alpha and scaling.
    /// </summary>
    public void SelectButton()
    {
        alphaChanger.alpha = 1;
        buttonTransform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.3f).SetEase(Ease.OutBounce);
    }

    /// <summary>
    /// Deselects the button by adjusting its alpha and scaling.
    /// </summary>
    public void DeselectButton()
    {
        alphaChanger.alpha = deselectedAlpha;
        buttonTransform.DOScale(Vector3.one, 0.3f);
    }
}
