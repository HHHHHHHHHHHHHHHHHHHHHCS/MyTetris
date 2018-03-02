using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayState : FSMState
{
    private PlayState()
    {
        stateID = StateID.Play;
        AddTransition(Transition.PauseGameClick, StateID.Menu);
    }

    public override void DoBeforeEntering()
    {
        GameCtrl.View.ShowGameUI();
        GameCtrl.CameraManager.ZoomIn();
        GameCtrl.MainGameManager.StartGame();
    }

    public override void DoBeforeLeaving()
    {
        GameCtrl.View.HideGameUI();
        GameCtrl.View.ShowRestartButton();
        GameCtrl.MainGameManager.PauseGame();
    }

    public void OnPauseButtonClick()
    {
        FSM.PerformTransition(Transition.PauseGameClick);
    }
}
