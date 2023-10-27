using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InAndOutObstacleComponent : MonoBehaviour
{

    [SerializeField] private ObstacleComponent leftObstacle;
    [SerializeField] private ObstacleComponent rightObstacle;
    private Animator animator;
    [SerializeField] private float startTimer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.SetTrigger("Start");
    }

    public void SetColor(Color color)
    {
        leftObstacle.SetColor(color);
        rightObstacle.SetColor(color);
    }

}
