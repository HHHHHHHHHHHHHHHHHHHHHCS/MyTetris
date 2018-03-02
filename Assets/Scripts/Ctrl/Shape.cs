using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    public Shape Init(Color col)
    {
        foreach (Transform t in transform)
        {
            if (t.CompareTag(NameLayerTag.block))
            {
                t.GetComponent<SpriteRenderer>().color = col;
            }
        }

        return this;
    }

    public void Fall()
    {
        transform.position += Vector3.down;
    }
}
