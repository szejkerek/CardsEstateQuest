using System.Collections;
using UnityEngine;

/// <summary>
/// Manages screen fading effects using a CanvasGroup component.
/// </summary>
public class FadeScreen : MonoBehaviour
{
    /// <summary>
    /// Gets the duration of the fade effect.
    /// </summary>
    public float FadeDuration => fadeDuration;

    /// <summary>
    /// The duration of the fade effect.
    /// </summary>
    [SerializeField] float fadeDuration = 2f;

    /// <summary>
    /// Determines if the fade effect should be applied on start.
    /// </summary>
    [SerializeField] bool fadeOnStart;

    /// <summary>
    /// The CanvasGroup component used to control alpha.
    /// </summary>
    CanvasGroup alphaChanger;

    private void Awake()
    {
        alphaChanger = GetComponent<CanvasGroup>();
        if (fadeOnStart)
        {
            FadeIn();
        }
    }

    /// <summary>
    /// Fades the screen in by increasing alpha.
    /// </summary>
    public void FadeIn()
    {
        Fade(1, 0);
    }

    /// <summary>
    /// Fades the screen out by decreasing alpha.
    /// </summary>
    public void FadeOut()
    {
        Fade(0, 1);
    }

    /// <summary>
    /// Fades the screen from one alpha value to another.
    /// </summary>
    /// <param name="alphaIn">The starting alpha value.</param>
    /// <param name="alphaOut">The target alpha value.</param>
    public void Fade(float alphaIn, float alphaOut)
    {
        StartCoroutine(FadeRoutine(alphaIn, alphaOut));
    }

    /// <summary>
    /// Performs the actual fade over time.
    /// </summary>
    /// <param name="alphaIn">The starting alpha value.</param>
    /// <param name="alphaOut">The target alpha value.</param>
    /// <returns>An IEnumerator for the fading routine.</returns>
    public IEnumerator FadeRoutine(float alphaIn, float alphaOut)
    {
        float timer = 0f;
        while (timer < fadeDuration)
        {
            alphaChanger.alpha = Mathf.Lerp(alphaIn, alphaOut, timer / fadeDuration);
            timer += Time.deltaTime;
            yield return null;
        }
        alphaChanger.alpha = alphaOut;
    }
}
