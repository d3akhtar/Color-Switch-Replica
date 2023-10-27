using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{

    [SerializeField] private Button retryButton;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private TextMeshProUGUI pointsText;
    private void Start()
    {
        retryButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.GameScene);
        });
        mainMenuButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.MainMenuScene);
        });
        MyGameManager.Instance.OnStateChanged += Game_OnStateChanged;
        this.gameObject.SetActive(false);
    }

    private void Game_OnStateChanged(object sender, System.EventArgs e)
    {
        pointsText.text = "Points: " + MyGameManager.Instance.GetPoints().ToString();
        this.gameObject.SetActive(MyGameManager.Instance.IsGameFinished());
    }
}
