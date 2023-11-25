using UnityEngine;

/// <summary>
/// Acts similarly to a singleton, but when creating a new instance, it overwrites the previous one.
/// </summary>
public abstract class StaticInstance<T> : MonoBehaviour where T : MonoBehaviour
{
    /// <summary>
    /// The unique instance of the class.
    /// </summary>
    public static T Instance { get; private set; }

    protected virtual void Awake()
    {
        Instance = this as T;
    }

    protected virtual void OnApplicationQuit()
    {
        Instance = null;
        Destroy(gameObject);
    }
}

/// <summary>
/// Transforms the static instance into a basic singleton.
/// </summary>
public abstract class Singleton<T> : StaticInstance<T> where T : MonoBehaviour
{
    protected override void Awake()
    {
        if (Instance != null)
        {
            return;
        }
        base.Awake();
    }
}
