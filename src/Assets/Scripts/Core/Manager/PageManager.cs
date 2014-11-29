using UnityEngine;
using System.Collections;
using DG.Tweening;
public class PageManager : MonoBehaviour
{
    public enum AnimationType
    {
        NULL,
        LeftToRight,
        RightToLeft,
        TopToBottom,
        BottomToTop,
        MiddleZoomIn,
        MiddleZoomOut,
    }
    static PageManager m_instance;
    public static PageManager Instance
    {
        get
        {
            return m_instance;
        }
    }
    BasePage m_currentPage = null;
    BasePage m_nextPage = null;
    BasePage m_DialogPage = null;
    public BasePage currentPage
    {
        get
        {
            return m_currentPage;
        }
    }

	public float AnimationDuration = 1.0f;
	public float AnimationScaleZoomIn = 10.0f;
	public float AnimationScaleZoomOut = 0.1f;
    void Awake()
    {
        m_instance = this;
    }

    void ShowPageAnimationFinish()
    {
        if (m_currentPage!=null)
        {
            m_currentPage.PageDidDisappear();
        }
        m_currentPage = m_nextPage;
        m_currentPage.PageDidAppear();
        m_nextPage = null;
    }
    void ShowDialogAnimationFinish()
    {
        m_DialogPage.PageDidAppear();
    }
    public void ShowPage(BasePage page, AnimationType type = AnimationType.NULL)
    {
        Tweener tweener = null;
        m_nextPage = page;
        this.gameObject.AddChild(m_nextPage.gameObject);
        if (m_currentPage)
        {
            m_currentPage.PageWillDisappear();
        }
        page.PageWillAppear();
        switch (type)
        {
            case AnimationType.NULL:
				page.transform.localPosition=new Vector3(0,0,0);
                ShowPageAnimationFinish();
                break;
            case AnimationType.LeftToRight:
                if (m_currentPage)
                {
					m_currentPage.transform.localPosition=new Vector3(0,0,0);
					m_currentPage.transform.DOLocalMoveX(Screen.width, AnimationDuration);
                }
				page.transform.localPosition=new Vector3(-Screen.width,0,0);
                tweener = page.transform.DOLocalMoveX(0, AnimationDuration);
				
                break;
            case AnimationType.RightToLeft:
                if (m_currentPage)
                {
					m_currentPage.transform.localPosition=new Vector3(0,0,0);
					m_currentPage.transform.DOLocalMoveX(-Screen.width, AnimationDuration);
                }
				page.transform.localPosition=new Vector3(Screen.width,0,0);
                tweener = page.transform.DOLocalMoveX(0, AnimationDuration);
                break;
            case AnimationType.TopToBottom:
				if (m_currentPage)
				{
					m_currentPage.transform.localPosition=new Vector3(0,0,0);
					m_currentPage.transform.DOLocalMoveY(Screen.height, AnimationDuration);
				}
				page.transform.localPosition=new Vector3(0,-Screen.height,0);
                tweener = page.transform.DOLocalMoveY(0, AnimationDuration);
				break;
            case AnimationType.BottomToTop:
				if (m_currentPage)
				{
					m_currentPage.transform.localPosition=new Vector3(0,0,0);
					m_currentPage.transform.DOLocalMoveY(-Screen.height, AnimationDuration);
				}
				page.transform.localPosition=new Vector3(0,Screen.height,0);
                tweener = page.transform.DOLocalMoveY(0, AnimationDuration);
				break;
            case AnimationType.MiddleZoomIn:
				if (m_currentPage)
				{
					m_currentPage.transform.localScale=new Vector3(1,1,1);
				}
				page.transform.localScale=new Vector3(AnimationScaleZoomIn,AnimationScaleZoomIn,AnimationScaleZoomIn);
                tweener = page.transform.DOScale(new Vector3(AnimationScaleZoomIn, AnimationScaleZoomIn, 1), AnimationDuration);
                break;
            case AnimationType.MiddleZoomOut:
				if (m_currentPage)
				{
					m_currentPage.transform.localScale=new Vector3(1,1,1);
				}
				page.transform.localScale=new Vector3(AnimationScaleZoomOut,AnimationScaleZoomOut,AnimationScaleZoomOut);
                tweener = page.transform.DOScale(new Vector3(AnimationScaleZoomOut, AnimationScaleZoomOut, 1), AnimationDuration);
                break;
            default:
                Debug.LogError("Unknoew AnimationType");
                break;
        }
        if (tweener!=null)
        {
            tweener.onComplete = ShowPageAnimationFinish;
        }
    }

    public void ShowDialog(BasePage page, AnimationType type = AnimationType.NULL)
    {
        Tweener tweener = null;
        HideDialog();
        m_DialogPage = page;
        page.PageWillAppear();
        page.PageDidDisappear();
        switch (type)
        {
            case AnimationType.NULL:
                page.transform.localPosition = new Vector3(0, 0, 0);
                break;
            case AnimationType.LeftToRight:
                page.transform.localPosition = new Vector3(-Screen.width, 0, 0);
                tweener = page.transform.DOLocalMoveX(0, AnimationDuration);

                break;
            case AnimationType.RightToLeft:
                page.transform.localPosition = new Vector3(Screen.width, 0, 0);
                tweener = page.transform.DOLocalMoveX(0, AnimationDuration);
                break;
            case AnimationType.TopToBottom:
                page.transform.localPosition = new Vector3(0, -Screen.height, 0);
                tweener = page.transform.DOLocalMoveY(0, AnimationDuration);
                break;
            case AnimationType.BottomToTop:
                page.transform.localPosition = new Vector3(0, Screen.height, 0);
                tweener = page.transform.DOLocalMoveY(0, AnimationDuration);
                break;
            case AnimationType.MiddleZoomIn:
                page.transform.localScale = new Vector3(AnimationScaleZoomIn, AnimationScaleZoomIn, AnimationScaleZoomIn);
                tweener = page.transform.DOScale(new Vector3(AnimationScaleZoomIn, AnimationScaleZoomIn, 1), AnimationDuration);
                break;
            case AnimationType.MiddleZoomOut:
                page.transform.localScale = new Vector3(AnimationScaleZoomOut, AnimationScaleZoomOut, AnimationScaleZoomOut);
                tweener = page.transform.DOScale(new Vector3(AnimationScaleZoomOut, AnimationScaleZoomOut, 1), AnimationDuration);
                break;
            default:
                Debug.LogError("Unknoew AnimationType");
                break;
        }
        if (tweener != null)
        {
            tweener.onComplete = ShowDialogAnimationFinish;
        }
    }

    public void HideDialog()
    {
        if (m_DialogPage)
        {
            m_DialogPage.PageWillDisappear();
            m_DialogPage.PageDidDisappear();
            GameObject.Destroy(m_DialogPage);
        }
    }
}
