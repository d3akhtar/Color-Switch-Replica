using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleComponent : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public bool IsObstacleSameColor(Color color)
    {
        return color == spriteRenderer.color;
    }

    public void SetColor(Color color)
    {
        spriteRenderer.color = color;
    }
}
