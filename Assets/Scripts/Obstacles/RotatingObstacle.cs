using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObstacle : _Obstacle
{

    private enum RotationDirection { Clockwise, CounterClockwise}

    [SerializeField] private RotationDirection rotationDirection;
    private int directionMultiplier;
    private float speed = 1.5f;

    private void Start()
    {
        SetComponentColors();
    }
    private void Update()
    {
        HandleRotation();
    }

    protected virtual void HandleRotation()
    {
        if (rotationDirection == RotationDirection.Clockwise)
        {
            directionMultiplier = -1;
        }
        else if (rotationDirection == RotationDirection.CounterClockwise)
        {
            directionMultiplier = 1;
        }

        transform.RotateAround(this.transform.position, new Vector3(0f, 0f, 1f), 45 * directionMultiplier * speed * Time.deltaTime);
    }
}
