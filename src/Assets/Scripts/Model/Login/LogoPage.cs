using UnityEngine;
using System.Collections;
using DG.Tweening;

public class LogoPage : BasePage
{
    static LogoPage m_instance;
    public static LogoPage Instance
    {
        get
        {
            if (m_instance==null)
            {
                m_instance = ResourceManager.Load("Prefab/Login/LogoPage").GetComponent<LogoPage>();
            }
            return m_instance;
        }
    }

    ~LogoPage()
    {
        m_instance = null;
    }

    UISprite StudioName;
    UITexture StudioLogo;

    void Awake()
    {
        StudioName = this.gameObject.FindChild("StudioName").GetComponent<UISprite>();
        StudioLogo = this.gameObject.FindChild("StudioLogo").GetComponent<UITexture>();
    }
    public override void PageDidAppear()
    {
        base.PageDidAppear();
        StudioLogo.transform.DOScale(new Vector3(1, 1, 1), 1.5f).ChangeStartValue(new Vector3(30, 30, 30)).SetEase(Ease.InQuad).onComplete = OnScaleComplete;
    }

    public override void PageDidDisappear()
    {
        base.PageDidDisappear();
        GameObject.Destroy(this.gameObject);
    }

    void OnScaleComplete()
    {
        StudioLogo.transform.DOShakePosition(3, 30, 40).onComplete = OnShakeComplete;
    }
    void OnShakeComplete()
    {
        DOTween.To(() => StudioName.alpha, x => StudioName.alpha = x, 0, 2);
        DOTween.To(() => StudioLogo.alpha, x => StudioLogo.alpha = x, 0, 2).onComplete = OnHideComplete;
    }
    void OnHideComplete()
    {
        PageManager.Instance.ShowPage(LoginPage.Instance);
    }
}
