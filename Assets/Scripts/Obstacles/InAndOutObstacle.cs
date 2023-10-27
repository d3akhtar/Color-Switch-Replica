using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InAndOutObstacle : _Obstacle
{

    private void Start()
    {
        SetComponentColors();
    }
    protected override void SetComponentColors()
    {
        int i = 0;

        foreach (Transform t in this.transform)
        {
            Color color = MyGameManager.Instance.GetColor(i);
            i++;
            t.GetComponent<InAndOutObstacleComponent>().SetColor(color);
        }
    }
}
