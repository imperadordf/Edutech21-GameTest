using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.Menu
{
    public class UIMenuController : UIMenu
    {
        [SerializeField] private Button buttonPlay;
        [SerializeField] private Button buttonOptions;

        public void Initialize(Action onClickPlay,Action onClickOptions)
        {
            buttonPlay?.onClick.AddListener(() =>
            {
                onClickPlay?.Invoke();
                buttonPlay.interactable = false;
            });

            buttonOptions?.onClick.AddListener(() =>
            {
                onClickOptions?.Invoke();
            });
        }

    }


}

