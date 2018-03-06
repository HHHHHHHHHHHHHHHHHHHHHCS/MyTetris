using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class View : MonoBehaviour
{
    private RectTransform logoName;
    private RectTransform menuUI;
    private RectTransform topBarUI;
    private RectTransform gameOverUI;
    private GameObject restartButton;
    private Text nowScoreText;
    private Text bestScoreText;
    private Text gameOverScoreText;

    public View Init()
    {
        logoName = transform.Find(NameLayerTag.logoNamePath) as RectTransform;
        menuUI = transform.Find(NameLayerTag.menuUIPath) as RectTransform;
        topBarUI = transform.Find(NameLayerTag.topBarPath) as RectTransform;
        gameOverUI = transform.Find(NameLayerTag.gameOverUIPath) as RectTransform;
        restartButton = transform.Find(NameLayerTag.restartButtonPath).gameObject;
        nowScoreText = transform.Find(NameLayerTag.nowScoreTextPath).GetComponent<Text>();
        bestScoreText = transform.Find(NameLayerTag.bestScoreTextPath).GetComponent<Text>();
        gameOverScoreText = transform.Find(NameLayerTag.gameOverScoreTextPath).GetComponent<Text>();


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
        topBarUI.gameObject.SetActive(true);
        topBarUI.DOAnchorPosY(-250f, 1f);
        nowScoreText.text = score.ToString();
        bestScoreText.text = bestScore.ToString();
    }

    public void RefreshScore(int score = 0)
    {
        nowScoreText.text = score.ToString();
    }

    public void HideGameUI()
    {
        topBarUI.DOAnchorPosY(250f, 1f)
            .onComplete += () => { topBarUI.gameObject.SetActive(false); };
    }

    public void ShowRestartButton()
    {
        restartButton.SetActive(true);
    }

    public void ShowGameOverUI(int score = 0)
    {
        gameOverUI.gameObject.SetActive(true);
        gameOverScoreText.text = score.ToString();
    }

    public void HideGameOverUI()
    {
        gameOverUI.gameObject.SetActive(false);
    }

}
