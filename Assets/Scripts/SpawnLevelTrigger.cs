using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLevelTrigger : MonoBehaviour
{

    private float quickMoveTimer = 3f;
    private bool start = false;

    private void Start()
    {
        Player.Instance.OnPlayerFirstMove += Player_OnPlayerFirstMove;
    }

    private void Player_OnPlayerFirstMove(object sender, System.EventArgs e)
    {
        start = true;
    }

    private void Update()
    {
        if (start)
        {
            if (quickMoveTimer > 0)
            {
                quickMoveTimer -= Time.deltaTime;
                this.transform.position = new Vector3(0f, this.transform.position.y + (50f * Time.deltaTime), 0f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out Endpoint endpoint))
        {
            endpoint.SpawnLevel();
        }
    }
}
