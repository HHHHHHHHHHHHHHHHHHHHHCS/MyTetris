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
        Ctrl.Instance.AudioManager.PlayCursor();
        Ctrl.Instance.FSMSystem.PerformTransition(Transition.StartButtonClick);
    }

    public void OnSettingButtonClick()
    {
        Ctrl.Instance.AudioManager.PlayCursor();
        Ctrl.Instance.View.ShowSettingUI();
    }

    public void OnAudioButtonClick()
    {
        Ctrl.Instance.AudioManager.PlayCursor();
        Ctrl.Instance.AudioManager.SwitchMuteAudio();
        Ctrl.Instance.View
            .ChangeMuteAudioImage(Ctrl.Instance.AudioManager.IsMute);
    }

    public void OnEmptyAudioButtonClick()
    {
        Ctrl.Instance.View.HideSettingUI();
    }

    public void OnRankButtonClick()
    {
        Ctrl.Instance.AudioManager.PlayCursor();
        var model = Ctrl.Instance.Model;
        Ctrl.Instance.View.ShowRankUI(
            model.NowScore, model.OldSaveData.BestScore, model.OldSaveData.GameCount);
    }

    public void OnEmptyRankButtonClick()
    {
        Ctrl.Instance.View.HideRankUI();
    }
}
