using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endpoint : MonoBehaviour
{
    [SerializeField] private Level level;
    [SerializeField] private bool ignoreSpawn = false;

    public void SpawnLevel()
    {
        if (!ignoreSpawn)
        {
            MyGameManager.Instance.SpawnLevel(this.transform.position);
        }
    }

    public void DeleteLevel()
    {
        if (level != null) { level.Delete(); }
    }
}
