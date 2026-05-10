using System.Collections;
using Game.Player;
using Game.Shared.Interactable;
using UnityEngine;

namespace Game.NPC
{
    public class NPCInteractable : MonoBehaviour, IInteractable
    {
        [SerializeField] protected Transform targetPosition;

        public bool Interactable { get => _interactable; set => _interactable = value; }
        protected bool _interactable = true;


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
                
            OnInteractable(player);
            StartCoroutine(DisableInteraction());
        }

        IEnumerator DisableInteraction()
        {
            Interactable = false;
            yield return new WaitForSeconds(2);
            Interactable = true;
        }

        public virtual void OnInteractable(PlayerController player)
        {

        }
    }

}
