using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class View : MonoBehaviour
{
    private RectTransform logoName;
    private RectTransform menuUI;
    private RectTransform topBar;
    private GameObject restartButton;
    private Text nowScoreText;
    private Text bestScoreText;

    public View Init()
    {
        logoName = transform.Find(NameLayerTag.logoNamePath) as RectTransform;
        menuUI = transform.Find(NameLayerTag.menuUIPath) as RectTransform;
        topBar = transform.Find(NameLayerTag.topBarPath) as RectTransform;
        restartButton = transform.Find(NameLayerTag.restartButtonPath).gameObject;
        nowScoreText = transform.Find(NameLayerTag.nowScoreText).GetComponent<Text>();
        bestScoreText = transform.Find(NameLayerTag.bestScoreText).GetComponent<Text>();

        RefreshScore(Ctrl.Instance.Model.NowScore
            , Ctrl.Instance.Model.OldSaveData.HighScore);
        return this;
    }

    public void ShowMenuUI()
    {
        logoName.gameObject.SetActive(true);
        logoName.DOAnchorPosY(-320f, 1f);
        menuUI.gameObject.SetActive(true);
        menuUI.DOAnchorPosY(200f, 1f);
    }

    public void HideMenuUI()
    {
        logoName.DOAnchorPosY(320f, 1f)
            .onComplete += () => { logoName.gameObject.SetActive(false); };
        menuUI.DOAnchorPosY(-200f, 1f)
            .onComplete += () => { menuUI.gameObject.SetActive(false); };
    }

    public void ShowGameUI(int score = 0, int bestScore = 0)
    {
        topBar.gameObject.SetActive(true);
        topBar.DOAnchorPosY(-250f, 1f);
        nowScoreText.text = score.ToString();
        bestScoreText.text = bestScore.ToString();
    }

    public void RefreshScore(int score = 0, int bestScore = -1)
    {
        nowScoreText.text = score.ToString();
        if (bestScore > 0)
        {
            bestScoreText.text = bestScore.ToString();
        }
    }

    public void HideGameUI()
    {
        topBar.DOAnchorPosY(250f, 1f)
            .onComplete += () => { topBar.gameObject.SetActive(false); };
    }

    public void ShowRestartButton()
    {
        restartButton.SetActive(true);
    }


}
