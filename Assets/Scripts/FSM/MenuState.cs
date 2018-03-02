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
        GameCtrl.View.ShowMenuUI();
        GameCtrl.CameraManager.ZoomOut();
    }

    public override void DoBeforeLeaving()
    {
        GameCtrl.View.HideMenuUI();
    }

    public void OnStartButtonClick()
    {
        FSM.PerformTransition(Transition.StartButtonClick);
    }
}
