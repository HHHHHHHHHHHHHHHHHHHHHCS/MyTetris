using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour
{
    public const int max_Columns = 10;
    public const int max_Rows = 20;
    public const float startPosX = -4.5f;
    public const float startPosY = -12.5f;
    public const float stepX = 1f;
    public const float stepY = 1;

    private Transform[,] map;

    public Model Init()
    {
        map = new Transform[max_Columns, max_Rows];
        return this;
    }

    public bool IsVaildMapPosition(Transform t)
    {
        foreach (Transform child in t)
        {
            if (child.CompareTag(NameLayerTag.block))
            {
                var pos = child.position.RoundToPos();
                if (!IsInsideMap(pos))
                {
                    return false;
                }
                if (pos.Value < max_Rows && map[pos.Key, pos.Value])
                {
                    return false;
                }
            }
        }
        return true;
    }

    public bool IsInsideMap(KeyValuePair<int, int> pos)
    {
        return pos.Key >= 0 && pos.Key < max_Columns && pos.Value >= 0;
    }

    public void PlaceShape(Transform t)
    {
        foreach (Transform child in t)
        {
            if (child.CompareTag(NameLayerTag.block))
            {
                var pos = child.position.RoundToPos();
                if (pos.Value < max_Rows)
                {
                    map[pos.Key, pos.Value] = child;
                }
            }
        }
        CheckMap();
    }

    private void CheckMap()
    {
        Queue<int> que = new Queue<int>();
        for (int y = 0; y < max_Rows; y++)
        {
            if (CheckIsRowFull(y))
            {
                DeleteRow(y);
                que.Enqueue(y);
            }
        }

        foreach (var y in que)
        {
            MoveDownRowsAbove(y);
        }
    }


    private bool CheckIsRowFull(int row)
    {
        for (int x = 0; x < max_Columns; x++)
        {
            if (!map[x, row])
            {
                return false;
            }
        }
        return true;
    }

    private void DeleteRow(int row)
    {
        for (int x = 0; x < max_Columns; x++)
        {
            Destroy(map[x, row].gameObject);
            map[x, row] = null;
        }
    }

    private void MoveDownRowsAbove(int row)
    {
        for (int y = row; y < max_Rows - 1; y++)
        {
            for (int x = 0; x < max_Columns; x++)
            {
                if (map[x, y + 1])
                {
                    map[x, y] = map[x, y + 1];
                    map[x, y + 1] = null;
                    map[x, y].position += stepX * Vector3.down;
                }
            }
        }
    }
}
