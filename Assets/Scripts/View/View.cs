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
    private RectTransform setttingUI;
    private RectTransform rankUI;
    private GameObject restartButton;
    private GameObject muteAudioImage;
    private Text nowScoreText;
    private Text bestScoreText;
    private Text gameOverScoreText;
    private Text rankNowScoreText;
    private Text rankBestScoreText;
    private Text rankGameCountText;

    public View Init()
    {
        logoName = transform.Find(NameLayerTag.logoNamePath) as RectTransform;
        menuUI = transform.Find(NameLayerTag.menuUIPath) as RectTransform;
        topBarUI = transform.Find(NameLayerTag.topBarUIPath) as RectTransform;
        gameOverUI = transform.Find(NameLayerTag.gameOverUIPath) as RectTransform;
        setttingUI = transform.Find(NameLayerTag.settingUIPath) as RectTransform;
        rankUI = transform.Find(NameLayerTag.rankUIPath) as RectTransform;
        restartButton = transform.Find(NameLayerTag.restartButtonPath).gameObject;
        muteAudioImage=transform.Find(NameLayerTag.muteAudioImagePath).gameObject;
        nowScoreText = transform.Find(NameLayerTag.nowScoreTextPath).GetComponent<Text>();
        bestScoreText = transform.Find(NameLayerTag.bestScoreTextPath).GetComponent<Text>();
        gameOverScoreText = transform.Find(NameLayerTag.gameOverScoreTextPath).GetComponent<Text>();
        rankNowScoreText = transform.Find(NameLayerTag.rankNowScoreText).GetComponent<Text>();
        rankBestScoreText = transform.Find(NameLayerTag.rankBestScoreText).GetComponent<Text>();
        rankGameCountText = transform.Find(NameLayerTag.rankGameCountText).GetComponent<Text>();


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

    public void ShowSettingUI()
    {
        setttingUI.gameObject.SetActive(true);
        setttingUI.GetChild(0).localScale = Vector3.zero;
        setttingUI.GetChild(0).DOScale(Vector3.one, 0.5f);
    }

    public void HideSettingUI()
    {
        setttingUI.gameObject.SetActive(false);
    }


    public void ChangeMuteAudioImage(bool tf)
    {
        muteAudioImage.SetActive(tf);
    }

    public void ShowRankUI(int nowScore,int bestScore,int gameCount)
    {
        rankNowScoreText.text = nowScore.ToString();
        rankBestScoreText.text = bestScore.ToString();
        rankGameCountText.text = gameCount.ToString();
        rankUI.gameObject.SetActive(true);
        rankUI.GetChild(0).localScale = Vector3.zero;
        rankUI.GetChild(0).DOScale(Vector3.one, 0.5f);
    }

    public void HideRankUI()
    {
        rankUI.gameObject.SetActive(false);
    }
}
