using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointsText;

    private void Start()
    {
        pointsText.text = "0";
        MyGameManager.Instance.OnPointsUpdate += MyGameManager_OnPointsUpdate;
    }

    private void MyGameManager_OnPointsUpdate(object sender, System.EventArgs e)
    {
        pointsText.text = MyGameManager.Instance.GetPoints().ToString();
    }
}
