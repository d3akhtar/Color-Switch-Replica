using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Obstacle : MonoBehaviour
{

    public event EventHandler OnObjectDestroyIfPass;
    private Transform cameraTransform;
    private float offset = 10f;

    private void Awake()
    {
        cameraTransform = FindObjectOfType<Follow>().GetComponent<Transform>();
    }

    private void Update()
    {
        DestroyIfPass();
    }

    protected virtual void SetComponentColors()
    {
        int i = 0;
        foreach (Transform component in this.transform)
        {
            Color color = MyGameManager.Instance.GetColor(i);
            i++;
            component.GetComponent<ObstacleComponent>().SetColor(color);
        }
    }
    public void DestroyIfPass()
    {
        if (cameraTransform.position.y > this.transform.position.y + offset)
        { 
            OnObjectDestroyIfPass?.Invoke(this, EventArgs.Empty);
            Destroy(this.gameObject);
        }
    }
}
