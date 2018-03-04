using System.Collections.Generic;
using UnityEngine;

public static class Vector3Extension
{
    public static KeyValuePair<int, int> RoundToPos(this Vector3 v)
    {
        KeyValuePair<int, int> kvp;
        int x = (int)Mathf.Round(((v.x - Model.startPosX) / Model.stepX));
        int y = (int)Mathf.Round(((v.y - Model.startPosY) / Model.stepY));
        kvp = new KeyValuePair<int, int>(x, y);
        return kvp;
    }
}
