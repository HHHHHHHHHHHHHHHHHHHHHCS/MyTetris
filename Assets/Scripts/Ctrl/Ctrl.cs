using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ctrl : MonoBehaviour
{
    public static Ctrl Instance;

    public Model Model { get; private set; }
    public View View { get; private set; }
    public CameraManager CameraManager { get; private set; }
    public MainGameManager MainGameManager { get; private set; }
    public AudioManager AudioManager { get; private set; }
    public FSMSystem FSMSystem { get; private set; }


    private void Awake()
    {
        Instance = this;
        Model = GameObject.Find("Model").GetComponent<Model>().Init();
        View = GameObject.Find("View").GetComponent<View>().Init();
        CameraManager = GameObject.Find(NameLayerTag.mainCameraPath).GetComponent<CameraManager>();
        MainGameManager = transform.GetComponent<MainGameManager>().Init();
        AudioManager = transform.GetComponent<AudioManager>().Init();
        MakekFSM();
    }

    private void Start()
    {

    }

    private void MakekFSM()
    {
        FSMSystem = new FSMSystem();
        FSMState[] states = GetComponentsInChildren<FSMState>(true);
        MenuState s = null;
        foreach (FSMState state in states)
        {
            FSMSystem.AddState(state,this);
            if (state is MenuState)
            {
                s = (MenuState)state;
            }
        }
        FSMSystem.SetCurrentState(s);
    }
}
