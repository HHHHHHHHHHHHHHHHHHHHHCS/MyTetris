using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MainGameManager : MonoBehaviour
{
    [SerializeField]
    private Shape[] shapes;
    [SerializeField]
    private Color[] colors;

    private bool isPause = true;//游戏是否暂停，默认是暂停的
    private Shape currentShape = null;

    private void Update()
    {
        if (isPause) return;
        if(!currentShape)
        {
            SpawnShape();
        }
    }

    public void StartGame()
    {
        isPause = false;
    }

    public void PauseGame()
    {
        isPause = true;
    }

    private void SpawnShape()
    {
        int index = UnityEngine.Random.Range(0, shapes.Length);
        int indexColor = UnityEngine.Random.Range(0, colors.Length);
        currentShape = Instantiate(shapes[index]).Init(colors[indexColor]);
    }
}
