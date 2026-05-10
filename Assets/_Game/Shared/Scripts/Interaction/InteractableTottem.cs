using System.Collections;
using Cinemachine;
using Game.Player;
using UnityEngine;

namespace Game.Shared.Interactable
{
    public class InteractableTottem : MonoBehaviour, IInteractable
    {
        [SerializeField] protected Transform targetPosition;
        [SerializeField] private CinemachineVirtualCamera virtualCamera;

        protected void Awake()
        {
            if (targetPosition == null)
            {
                targetPosition = transform;
            }
        }

        public Transform GetTransform()
        {
            return targetPosition;
        }

        public void Interact(PlayerController player)
        {
            virtualCamera.Priority = 20;
            StartCoroutine(DisableInteraction());
        }

        IEnumerator DisableInteraction()
        {
            yield return new WaitForSeconds(2);
            virtualCamera.Priority = 0;
        }
    }

}
