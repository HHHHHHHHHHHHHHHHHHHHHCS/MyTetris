using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class View : MonoBehaviour
{
    private RectTransform logoName;
    private RectTransform menuUI;
    private RectTransform topBar;
    private GameObject restartButton;

    private void Awake()
    {
        logoName = transform.Find(NameLayerTag.logoNamePath) as RectTransform;
        menuUI = transform.Find(NameLayerTag.menuUIPath) as RectTransform;
        topBar = transform.Find(NameLayerTag.topBarPath) as RectTransform;
        restartButton = transform.Find(NameLayerTag.restartButtonPath) .gameObject;
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

    public void ShowGameUI()
    {
        topBar.gameObject.SetActive(true);
        topBar.DOAnchorPosY(-250f, 1f);
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
