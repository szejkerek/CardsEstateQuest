using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// Enum representing different scenes in the game.
/// </summary>
public enum SceneEnum
{
    MainMenu,
    Gameplay,
    EndMenu
}

/// <summary>
/// Handles scene loading and transitions with fade effects.
/// </summary>
public class SceneLoader : Singleton<SceneLoader>
{
    /// <summary>
    /// Action triggered when the scene changes.
    /// </summary>
    public Action OnSceneChanged;

    /// <summary>
    /// Action triggered when the new scene is fully loaded.
    /// </summary>
    public Action OnSceneFullyLoaded;

    /// <summary>
    /// The fade screen used for transitions.
    /// </summary>
    [SerializeField] FadeScreen fadeScreen;

    /// <summary>
    /// Loads a scene by its index with fade effects.
    /// </summary>
    /// <param name="sceneIndex">The index of the scene to load.</param>
    public void LoadScene(int sceneIndex)
    {
        StartCoroutine(LoadSceneRoutine(sceneIndex));
    }

    /// <summary>
    /// Loads a scene by its enum value with fade effects.
    /// </summary>
    /// <param name="sceneEnum">The enum value representing the scene to load.</param>
    public void LoadScene(SceneEnum sceneEnum)
    {
        int sceneIndex = (int)sceneEnum;
        LoadScene(sceneIndex);
    }

    IEnumerator LoadSceneRoutine(int sceneIndex)
    {
        fadeScreen.FadeOut();
        yield return new WaitForSeconds(fadeScreen.FadeDuration);

        AsyncOperation operation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneIndex);
        operation.allowSceneActivation = false;

        float timer = 0f;
        while (timer <= fadeScreen.FadeDuration && !operation.isDone)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        OnSceneChanged?.Invoke();
        operation.allowSceneActivation = true;
        fadeScreen.FadeIn();

        OnSceneFullyLoaded?.Invoke();
    }
}
