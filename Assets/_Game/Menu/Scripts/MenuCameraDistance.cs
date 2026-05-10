using UnityEngine;

namespace Game.UI.Menu
{
    public class MenuCameraDistance : MonoBehaviour
    {
        [SerializeField] private Camera cam;
        [SerializeField] private Transform target;

        [SerializeField] private float targetAspect = 16f / 9f;
        [SerializeField] private float defaultDistance = 10f;

        private Vector3 dir;

        void Start()
        {
            dir = (cam.transform.position - target.position).normalized;
        }

        void Update()
        {
            float currentAspect = (float)Screen.width / Screen.height;

            float multiplier = currentAspect / targetAspect;

            float distance = defaultDistance;

            if (currentAspect > targetAspect)
            {
                distance *= multiplier;
            }

            cam.transform.position = target.position + dir * distance;
        }
    }
}

