using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button quitButton;

    private void Awake()
    {
        startButton.onClick.AddListener(() =>
        {
            // Load game scene
            Loader.Load(Loader.Scene.GameScene);
        });
        quitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });
        Time.timeScale = 1.0f;
    }
}
