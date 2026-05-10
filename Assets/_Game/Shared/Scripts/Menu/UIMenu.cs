using DG.Tweening;
using UnityEngine;

public class UIMenu : MonoBehaviour
{
    [SerializeField] protected CanvasGroup canvasGroup;

    [Header("Values")]
    [Range(0,2)]
    [SerializeField] protected float timeFromFadeIn;
    [Range(0,2)]
    [SerializeField] protected float timeFromFadeOut;

    public virtual void SetActiveMenu(bool active)
    {
        if (active)
        {
            FadeOut();
        }
        else
        {
            FadeIn();
        }
    }


    protected void FadeIn()
    {
        ActiveObject(true);
        ActiveCanvasGroup(false);
        canvasGroup.DOFade(0, timeFromFadeIn).OnComplete(() =>
        {
            ActiveObject(false);
        });
    }

    protected void FadeOut()
    {
        ActiveObject(true);
        canvasGroup.DOFade(1, timeFromFadeOut).OnComplete(() =>
        {
            ActiveCanvasGroup(true);
        });
    }

    protected virtual void ActiveCanvasGroup(bool active)
    {
        canvasGroup.blocksRaycasts = active;
        canvasGroup.interactable = active;
    }

    protected virtual void ActiveObject(bool active)
    {
        canvasGroup.gameObject.SetActive(active);
    }
}

