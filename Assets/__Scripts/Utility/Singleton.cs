using UnityEngine;

/// <summary>
/// Acts similarly to a singleton, but when creating a new instance, it overwrites the previous one.
/// </summary>
public abstract class StaticInstance<T> : MonoBehaviour where T : MonoBehaviour
{
    /// <summary>
    /// Gets the instance of the static class.
    /// </summary>
    public static T Instance { get; private set; }

    /// <summary>
    /// Called when the script instance is being loaded.
    /// Sets the instance to the current instance of the derived class.
    /// </summary>
    protected virtual void Awake()
    {
        Instance = this as T;
    }

    /// <summary>
    /// Called when the application is quitting.
    /// Clears the instance and destroys the game object.
    /// </summary>
    protected virtual void OnApplicationQuit()
    {
        Instance = null;
        Destroy(gameObject);
    }
}

/// <summary>
/// Transforms a static instance into a basic singleton.
/// </summary>
public abstract class Singleton<T> : StaticInstance<T> where T : MonoBehaviour
{
    /// <summary>
    /// Called when the script instance is being loaded.
    /// Ensures that only one instance of the class exists.
    /// </summary>
    protected override void Awake()
    {
        if (Instance != null)
        {
            return;
        }
        base.Awake();
    }
}
