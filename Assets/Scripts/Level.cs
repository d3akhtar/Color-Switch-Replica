using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public void Delete()
    {
        foreach (Transform child in this.transform)
        {
            Destroy(child.gameObject);
        }

        Destroy(this.gameObject);
    }
}
