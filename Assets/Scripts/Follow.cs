using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] private Transform followTransform;
    [SerializeField] private float offsetY = 1f;

    private void Update()
    {
        this.transform.position = new Vector3(transform.position.x, followTransform.position.y + offsetY, transform.position.z);
    }
}
