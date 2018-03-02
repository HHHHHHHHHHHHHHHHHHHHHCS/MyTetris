using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class View : MonoBehaviour
{
    private RectTransform logoName;
    private RectTransform menuUI;

    private void Awake()
    {
        logoName = transform.Find(ObjectsName.logoNamePath) as RectTransform;
        menuUI = transform.Find(ObjectsName.menuUIPath) as RectTransform;
    }

    public void ShowMenu()
    {
        logoName.gameObject.SetActive(true);
        logoName.DOAnchorPosY(-320f, 1f);
        menuUI.gameObject.SetActive(true);
        menuUI.DOAnchorPosY(200f, 1f);
    }

    public void HideMenu()
    {
        logoName.DOAnchorPosY(320f, 1f)
            .onComplete += () => { logoName.gameObject.SetActive(false); };
        menuUI.DOAnchorPosY(-200f, 1f)
            .onComplete += () => { menuUI.gameObject.SetActive(false); };
    }
}
