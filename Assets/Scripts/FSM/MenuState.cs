using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuState : FSMState
{
    private MenuState()
    {
        stateID = StateID.Menu;
        AddTransition(Transition.StartButtonClick, StateID.Play);
    }

    public override void DoBeforeEntering()
    {
        Ctrl.Instance.View.ShowMenuUI();
        Ctrl.Instance.CameraManager.ZoomOut();
    }

    public override void DoBeforeLeaving()
    {
        Ctrl.Instance.View.HideMenuUI();
    }

    public void OnStartButtonClick()
    {
        Ctrl.Instance.FSMSystem.PerformTransition(Transition.StartButtonClick);
    }
}
