using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayState : FSMState
{
    private PlayState()
    {
        stateID = StateID.Play;
        AddTransition(Transition.PauseGameClick, StateID.Menu);
    }

    public override void DoBeforeEntering()
    {
        Ctrl.Instance.View.ShowGameUI(Ctrl.Instance.Model.NowScore
            , Ctrl.Instance.Model.OldSaveData.BestScore);
        Ctrl.Instance.CameraManager.ZoomIn();
        Ctrl.Instance.MainGameManager.StartGame();
    }

    public override void DoBeforeLeaving()
    {
        Ctrl.Instance.View.HideGameUI();
        Ctrl.Instance.MainGameManager.PauseGame();
    }

    public void OnPauseButtonClick()
    {
        Ctrl.Instance.AudioManager.PlayCursor();
        Ctrl.Instance.View.ShowRestartButton();
        Ctrl.Instance.FSMSystem.PerformTransition(Transition.PauseGameClick);
    }

    public void OnHomeButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
