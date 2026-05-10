using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Gameplay
{
    public class UIGameplayController: MonoBehaviour
    {
        [SerializeField] private Button buttonReturnToMenu;

        public void Initialize(Action onReturnToMenu)
        {
            buttonReturnToMenu.onClick.AddListener(() =>
            {
                onReturnToMenu?.Invoke();
            });
        }
    }

}
