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
        Ctrl.Instance.View.ShowGameUI();
        Ctrl.Instance.CameraManager.ZoomIn();
        Ctrl.Instance.MainGameManager.StartGame();
    }

    public override void DoBeforeLeaving()
    {
        Ctrl.Instance.View.HideGameUI();
        Ctrl.Instance.View.ShowRestartButton();
        Ctrl.Instance.MainGameManager.PauseGame();
    }

    public void OnPauseButtonClick()
    {
        Ctrl.Instance.AudioManager.PlayCursor();
        Ctrl.Instance.FSMSystem.PerformTransition(Transition.PauseGameClick);
    }
}
