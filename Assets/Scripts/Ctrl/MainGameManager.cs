﻿using System;
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

    private const float stepTime = 0.8f;

    private bool isPause = true;//游戏是否暂停，默认是暂停的
    private Shape currentShape = null;
    private float stepTimer;

    private MainGameManager()
    {
        stepTimer = stepTime;
    }

    public MainGameManager Init()
    {
        return this;
    }

    private void Update()
    {
        if (isPause) return;
        if(!currentShape)
        {
            SpawnShape();
        }

        if(stepTimer<=0)
        {
            stepTimer = stepTime;
            if (currentShape)
            {
                currentShape.Fall();
            }
        }
        else
        {
            stepTimer -= Time.deltaTime;
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

    public void CleanCurrentShape()
    {
        currentShape = null;
    }
}
