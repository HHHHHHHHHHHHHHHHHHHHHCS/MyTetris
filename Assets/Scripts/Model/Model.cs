﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour
{
    public const int max_Rows = 10;
    public const int max_Columns = 20;
    public const float startPosX = -4.5f;
    public const float startPosY = -12.5f;
    public const float stepX = 1f;
    public const float stepY = 1;

    private Transform[,] map;

    private Model()
    {
        map = new Transform[max_Rows, max_Columns];
    }

    public bool IsVaildMapPosition(Transform t)
    {
        foreach(Transform child in t)
        {
            if(t.CompareTag(NameLayerTag.block))
            {
                var pos = child.position.RoundToPos();
                if(!IsInsideMap(pos))
                {
                    return false;
                }
                if(!map[pos.Key,pos.Value])
                {
                    return false;
                }
            }
        }
        return true;
    }

    public bool IsInsideMap(KeyValuePair<int,int> pos)
    {
        return pos.Key >= 0 && pos.Key < max_Rows && pos.Value >= 0;
    }
}
