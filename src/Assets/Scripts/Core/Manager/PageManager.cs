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
    public BasePage currentPage
    {
        get
        {
            return m_currentPage;
        }
    }


    void Awake()
    {
        m_instance = this;
    }

    void AnimationFinish()
    {
        if (m_currentPage!=null)
        {
            m_currentPage.PageDidDisappear();
        }
        m_currentPage = m_nextPage;
        m_currentPage.PageDidAppear();
        m_nextPage = null;
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
                AnimationFinish();
                break;
            case AnimationType.LeftToRight:
                if (m_currentPage)
                {
                    m_currentPage.transform.DOLocalMoveX(Screen.width, 1);
                }
                page.transform.DOLocalMoveX(0, 1).ChangeStartValue(-Screen.width);
                break;
            case AnimationType.RightToLeft:
                if (m_currentPage)
                {
                    m_currentPage.transform.DOLocalMoveX(-Screen.width, 1);
                }
                page.transform.DOLocalMoveX(0, 1).ChangeStartValue(Screen.width);
                break;
            case AnimationType.TopToBottom:
                break;
            case AnimationType.BottomToTop:
                break;
            case AnimationType.MiddleZoomIn:
                break;
            case AnimationType.MiddleZoomOut:
                break;
            default:
                break;
        }
        if (tweener!=null)
        {
            tweener.onComplete = AnimationFinish;
        }
    }

    public void ShowDialog(BasePage page, AnimationType type = AnimationType.NULL)
    {
        Tweener tweener = null;
        switch (type)
        {
            case AnimationType.NULL:
                break;
            case AnimationType.LeftToRight:
                break;
            case AnimationType.RightToLeft:
                break;
            case AnimationType.TopToBottom:
                break;
            case AnimationType.BottomToTop:
                break;
            case AnimationType.MiddleZoomIn:
                break;
            case AnimationType.MiddleZoomOut:
                break;
            default:
                break;
        }
    }

    public void HideDialog()
    {

    }
}
