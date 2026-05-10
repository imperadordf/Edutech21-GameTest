using Game.Loading;
using Game.UI.Menu;
using UnityEngine;

namespace Game.Gameplay
{
    public class GameplayController : MonoBehaviour
    {
        public const string NAME_SCENE = "Gameplay";

        [SerializeField] private UIGameplayController uIGameplayController;

        void Start()
        {
            uIGameplayController.Initialize(() =>
            {
               LoadSceneController.Instance.LoadScene(MenuController.NAME_SCENE); 
            });
        }
    }

}
