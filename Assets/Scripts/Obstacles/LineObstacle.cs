using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineObstacle : _Obstacle
{

    [SerializeField] private Transform lineSegments;
    private Vector3 defaultPosition = Vector3.zero;
    private float loopOffset = 8f;
    [SerializeField] private float loopSpeed;

    private void Start()
    {
        SetComponentColors();
        defaultPosition.y = transform.position.y;
        defaultPosition.z = transform.position.z;
    }
    private void Update()
    {
        transform.position += new Vector3(1, 0, 0) * loopSpeed * Time.deltaTime;
        CheckIfLoop();
    }

    private void CheckIfLoop()
    {
        if (transform.position.x >= defaultPosition.x + loopOffset)
        {
            transform.position = defaultPosition;
        }
    }

    protected override void SetComponentColors()
    {
        int i = 0;
        foreach (Transform line in lineSegments)
        {
            Color color = MyGameManager.Instance.GetColor(i % 4);
            i++;
            line.GetComponent<ObstacleComponent>().SetColor(color);
        }
    }

}
