﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ctrl : MonoBehaviour
{
    public static Ctrl Instance;

    public Model Model { get; private set; }
    public View View { get; private set; }
    public CameraManager CameraManager { get; private set; }
    public MainGameManager MainGameManager { get; private set; }

    private FSMSystem fsm;

    private void Awake()
    {
        Instance = this;
        Model = GameObject.Find("Model").GetComponent<Model>();
        View = GameObject.Find("View").GetComponent<View>();
        CameraManager = GameObject.Find(NameLayerTag.mainCameraPath).GetComponent<CameraManager>();
        MainGameManager = transform.GetComponent<MainGameManager>();
    }

    private void Start()
    {
        MakekFSM();
    }

    private void MakekFSM()
    {
        fsm = new FSMSystem();
        FSMState[] states = GetComponentsInChildren<FSMState>(true);
        MenuState s = null;
        foreach (FSMState state in states)
        {
            fsm.AddState(state,this);
            if (state is MenuState)
            {
                s = (MenuState)state;
            }
        }
        fsm.SetCurrentState(s);
    }
}
