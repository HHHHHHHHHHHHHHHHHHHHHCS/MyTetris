using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawn : MonoBehaviour
{
    [SerializeField]
    private bool needSpawn;
    [SerializeField]
    private GameObject backgroundBlockPrefab;

    private int rowCount = Model.max_Rows;
    private int columnCount = Model.max_Columns;
    private float startPosX = Model.startPosX;
    private float startPosY = Model.startPosY;
    private float stepX = Model.stepX;
    private float stepY = Model.stepY;

    private void Awake()
    {
        if (needSpawn)
        {
            Spawn();
        }
        Destroy(this);
    }

    private void Spawn()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
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

    private void SpawnPrefab(int x, int y, Transform parent)
    {
        Vector3 pos = new Vector3(startPosX + x * stepX, startPosY + y * stepY, 0);
        var go = Instantiate(backgroundBlockPrefab, pos, Quaternion.identity, parent);
        go.name = string.Format("Block {0}_{1}", x, y);
    }
}
