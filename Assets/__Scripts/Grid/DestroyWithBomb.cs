using System;
using UnityEngine;

/// <summary>
/// Handles the destruction of an object with a bomb when the "B" key is pressed.
/// </summary>
public class DestroyWithBomb : MonoBehaviour
{
    /// <summary>
    /// Event that triggers when a bomb is used on the object.
    /// </summary>
    public Action BombUsed;

    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            BombUsed?.Invoke();
        }
    }
}
