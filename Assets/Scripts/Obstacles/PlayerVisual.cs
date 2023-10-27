using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void SetPlayerColor(Color color)
    {
        spriteRenderer.color = color;
    }

    public Color GetPlayerColor()
    {
        return spriteRenderer.color;
    }
}
