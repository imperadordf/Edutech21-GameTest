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

        public bool Interactable { get => _interactable; set => _interactable = value; }
        private bool _interactable = true;

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
            if (!Interactable)
                return;

            virtualCamera.Priority = 20;
            StartCoroutine(DisableInteraction());
        }

        IEnumerator DisableInteraction()
        {
            Interactable = false;
            yield return new WaitForSeconds(2);
            Interactable = true;
            virtualCamera.Priority = 0;
        }
    }

}
