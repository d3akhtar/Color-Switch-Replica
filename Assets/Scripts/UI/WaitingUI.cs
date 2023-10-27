using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingUI : MonoBehaviour
{
    private void Start()
    {
        MyGameManager.Instance.OnStateChanged += Game_OnStateChanged;
    }

    private void Game_OnStateChanged(object sender, System.EventArgs e)
    {
        this.gameObject.SetActive(MyGameManager.Instance.IsWaiting());
    }
}
