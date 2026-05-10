using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game.Loading
{
    public class LoadSceneController : MonoBehaviour
    {
        public static LoadSceneController Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = Instantiate(Resources.Load<LoadSceneController>(RESOURCE_NAME_LOADING_PREFAB));
                    DontDestroyOnLoad(_Instance.gameObject);
                }

                return _Instance;
            }
        }

        [SerializeField] private UILoadSceneController uiLoadSceneController;

        private const string RESOURCE_NAME_LOADING_PREFAB = "CanvasLoading";
        private static LoadSceneController _Instance;

        private void Awake()
        {
            if (_Instance == null)
            {
                _Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else if(_Instance.gameObject != gameObject)
            {
                Destroy(gameObject);
            }      
        }

        public void LoadScene(string nameScene, LoadSceneMode loadSceneMode = LoadSceneMode.Single)
        {
            gameObject.SetActive(true);
            StartCoroutine(LoadAsync(nameScene, loadSceneMode));
        }

        private IEnumerator LoadAsync(string nameScene, LoadSceneMode loadSceneMode)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(nameScene, loadSceneMode);

            uiLoadSceneController.SetActiveMenu(true);

            operation.allowSceneActivation = false;

            while (operation.progress < 0.9f)
            {
                float progress = Mathf.Clamp01(operation.progress / 0.9f);

                yield return null;
            }

            yield return new WaitForSeconds(1f);

            uiLoadSceneController.SetActiveMenu(false);
            operation.allowSceneActivation = true;
        }
    }
}

