using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DifficultyButton : MonoBehaviour
{
    [SerializeField, Range(0f, 1f)] float deselectedAlpha;
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] Image image;

    public IDifficulty Difficulty => difficulty;

    IDifficulty difficulty;
    CanvasGroup alphaChanger;
    RectTransform buttonTransform;

    private void Awake()
    {
        alphaChanger = GetComponent<CanvasGroup>();
        buttonTransform = GetComponent<RectTransform>();

        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        DifficultyButtonsController.Instance.ManageSelectedButton(this);
    }

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

    public void SelectButton()
    {
        alphaChanger.alpha = 1;
        buttonTransform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.3f).SetEase(Ease.OutBounce);
    }

    public void DeselectButton()
    {
        alphaChanger.alpha = deselectedAlpha;
        buttonTransform.DOScale(Vector3.one, 0.3f);
    }
}
