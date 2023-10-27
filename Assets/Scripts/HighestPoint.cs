using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighestPoint : MonoBehaviour
{
    [SerializeField] private Player player;
    private void FixedUpdate()
    {
        if (player.transform.position.y > this.transform.position.y)
        {
            this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        }
    }
}
