﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{


    private Transform pivot;
    private bool isSpeedUp;


    public Shape Init(Color col)
    {
        pivot = transform.Find(NameLayerTag.pivotPath);

        foreach (Transform t in transform)
        {
            if (t.CompareTag(NameLayerTag.block))
            {
                t.GetComponent<SpriteRenderer>().color = col;
            }
        }
        return this;
    }

    public void SelfUpdate()
    {

        InputMove();
        InputRotate();
        if (!isSpeedUp)
        {
            InputSpeedUp();
        }
    }

    private void InputMove()
    {
        int hor = 0;
        if (Input.GetKeyDown(KeyCode.A)
            || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            hor = -1;
        }
        else if (Input.GetKeyDown(KeyCode.D)
            || Input.GetKeyDown(KeyCode.RightArrow))
        {
            hor = 1;
        }
        if (hor != 0)
        {
            transform.position += new Vector3(hor, 0, 0);
            if (!Ctrl.Instance.Model.IsVaildMapPosition(transform))
            {
                transform.position -= new Vector3(hor, 0, 0);
            }
            else
            {
                Ctrl.Instance.AudioManager.PlayControl();
            }
        }
    }

    private void InputRotate()
    {
        if (Input.GetKeyDown(KeyCode.W)
            || Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.RotateAround(pivot.position, Vector3.forward, -90);
            if (!Ctrl.Instance.Model.IsVaildMapPosition(transform))
            {
                transform.RotateAround(pivot.position, Vector3.forward, 90);
            }
            else
            {
                Ctrl.Instance.AudioManager.PlayControl();
            }
        }
    }

    private void InputSpeedUp()
    {
        if (Input.GetKeyDown(KeyCode.S)
            || Input.GetKeyDown(KeyCode.DownArrow))
        {
            isSpeedUp = true;
            Ctrl.Instance.MainGameManager.SpeedUp();
        }
    }

    public void Fall()
    {
        transform.position += Model.stepX * Vector3.down;
        if (!Ctrl.Instance.Model.IsVaildMapPosition(transform))
        {
            transform.position -= Vector3.down;
            Ctrl.Instance.MainGameManager.CleanCurrentShape();
            var isPlace = Ctrl.Instance.Model.PlaceShape(transform);
            var isGameOver = Ctrl.Instance.Model.IsGameOver(transform);
            if(isGameOver)
            {
                Ctrl.Instance.MainGameManager.PauseGame();
                Ctrl.Instance.View.ShowGameOverUI(Ctrl.Instance.Model.NowScore);
                Ctrl.Instance.Model.SaveData();
            }
            else if (isPlace)
            {
                Ctrl.Instance.AudioManager.PlayLineClean();
            }
        }
        else
        {
            Ctrl.Instance.AudioManager.PlayDrop();
        }
    }
}
