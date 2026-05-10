using Game.Gameplay;
using Game.Loading;
using Game.Shared;
using UnityEngine;

namespace Game.UI.Menu
{
    public class MenuController : MonoBehaviour
    {
        public const string NAME_SCENE = "Menu";
        
        [Header("Menus")]
        [SerializeField] private UIMenuController uIMenuController;
        [SerializeField] private UIOptionsController uIOptionsController;

        private bool _isMuted = false;
        private string KEY_PLAYER_PREFS_AUDIOMUTE = "AudioMuted";

        void Awake()
        {
            if(PlayerPrefs.HasKey(KEY_PLAYER_PREFS_AUDIOMUTE))
                MuteAudio(PlayerPrefs.GetInt(KEY_PLAYER_PREFS_AUDIOMUTE) == 0);
        }

        void Start()
        {
            uIMenuController.Initialize(Play,ActiveOptions);
            uIOptionsController.Initialize(MuteAudio, ActiveMenu, _isMuted);
        }

        private void MuteAudio(bool value)
        {
            _isMuted = value;
            int valueAudio = _isMuted ? 0 : 1;
            PlayerPrefs.SetInt(KEY_PLAYER_PREFS_AUDIOMUTE, valueAudio);
            AudioListener.volume = valueAudio;
        }

        private void ActiveMenu()
        {
            uIOptionsController.SetActiveMenu(false);
            uIMenuController.SetActiveMenu(true);
        }

        private void ActiveOptions()
        {
            uIMenuController.SetActiveMenu(false);
            uIOptionsController.SetActiveMenu(true);
        }

        private void Play()
        {
            LoadSceneController.Instance.LoadScene(GameplayController.NAME_SCENE);
        }
    }
}

