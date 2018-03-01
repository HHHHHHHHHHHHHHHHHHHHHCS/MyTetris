using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawn : MonoBehaviour
{
    [SerializeField]
    private bool needSpawn;
    [SerializeField]
    private GameObject backgroundBlockPrefab;

    [SerializeField]
    private int rowCount = 10;
    [SerializeField]
    private int columnCount = 12;
    [SerializeField]
    private float startPosX = -4.5f;
    [SerializeField]
    private float startPosY = -6;
    [SerializeField]
    private float stepX = 1f;
    [SerializeField]
    private float stepY = 1;

    private void Awake()
    {
        if(needSpawn)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        for (int y = 0; y < columnCount; y++)
        {
            Transform parent = new GameObject("Row" + y).transform;
            parent.SetParent(transform);
            for (int x = 0; x < rowCount; x++)
            {
                SpawnPrefab(x, y, parent);
            }
        }
    }

    private void SpawnPrefab(int x, int y,Transform parent)
    {
        Vector3 pos = new Vector3(startPosX + x * stepX, startPosY + y * stepY, 0);
        var go = Instantiate(backgroundBlockPrefab, pos, Quaternion.identity, parent);
        go.name = string.Format( "Block {0}_{1}",x,y);
    }
}
