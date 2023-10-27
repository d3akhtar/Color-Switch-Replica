using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteLevelTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out Endpoint endpoint))
        {
            endpoint.DeleteLevel();
        }
    }
}
