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
        GameCtrl.View.ShowMenu();
        GameCtrl.CameraManager.ZoomIn();
    }

    public override void DoBeforeLeaving()
    {
        GameCtrl.View.HideMenu();
        GameCtrl.CameraManager.ZoomOut();
    }

    public void OnStartButtonClick()
    {
        FSM.PerformTransition(Transition.StartButtonClick);
    }
}
