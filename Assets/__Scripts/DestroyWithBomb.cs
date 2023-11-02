using System;
using UnityEngine;

public class DestroyWithBomb : MonoBehaviour
{
    public Action BombUsed;
    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            BombUsed?.Invoke();
        }
    }
}
