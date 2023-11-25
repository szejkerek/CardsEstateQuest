using UnityEngine;
using UnityEngine.AddressableAssets;

/// <summary>
/// Initializes and executes necessary systems before scene loading.
/// </summary>
public static class SystemBootstrapper
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Execute()
    {
        Object.DontDestroyOnLoad(Addressables.InstantiateAsync("PersistentSystems").WaitForCompletion());
    }
}
