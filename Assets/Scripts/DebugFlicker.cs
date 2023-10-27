using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugFlicker : MonoBehaviour
{

    public static DebugFlicker Instance { get; private set; }
    [SerializeField] private Image image;

    private bool flicker = false;
    private float timer = .3f;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        image.enabled = false;
    }

    private void Update()
    {
        if (flicker)
        {
            image.enabled = true;
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                image.enabled = false;
                flicker = false;
                timer = .3f;
            }
        }
    }
    public void Flicker()
    {
        flicker = true;
    }
}
