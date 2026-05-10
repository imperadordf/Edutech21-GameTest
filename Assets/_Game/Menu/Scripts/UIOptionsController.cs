using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.Menu
{
    public class UIOptionsController : UIMenu
    {

        [Header("Buttons")]
        [SerializeField] private Button buttonMuteAudio;
        [SerializeField] private Button buttonReturn;

        [Header("Texts")]
        [SerializeField] private TextMeshProUGUI textMuteAudio;

        private const string VALUE_ON = "Audio On";
        private const string VALUE_OFF = "Audio Off";

        private bool _isMuted;
        public void Initialize(Action<bool> onMuteAudio, Action onReturnMenu, bool isMuted)
        {
            SetMute(isMuted);
            buttonMuteAudio.onClick.AddListener(() =>
            {
                SetMute(!_isMuted);
                onMuteAudio?.Invoke(_isMuted);
            });
            buttonReturn.onClick.AddListener(() =>
            {
                onReturnMenu?.Invoke();
            });
        }

        private void SetMute(bool isMuted)
        {
            _isMuted = isMuted;
            textMuteAudio.text = _isMuted? VALUE_OFF: VALUE_ON;
        }

    }


}

