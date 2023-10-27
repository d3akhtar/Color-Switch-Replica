using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausedUI : MonoBehaviour
{

    [SerializeField] private Button resumeButton;
    [SerializeField] private Button mainMenuButton;

    private void Start()
    {
        MyGameManager.Instance.OnStateChanged += Game_OnStateChanged;
        this.gameObject.SetActive(false);

        resumeButton.onClick.AddListener(() =>
        {
            MyGameManager.Instance.TogglePause();
        });
        mainMenuButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.MainMenuScene);
        });
    }

    private void Game_OnStateChanged(object sender, System.EventArgs e)
    {
        this.gameObject.SetActive(MyGameManager.Instance.IsPaused());
    }
}
