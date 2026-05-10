using Game.Player;
using Game.Shared.Interactable;
using UnityEngine;

namespace Game.NPC
{
    public class NPCInteractable : MonoBehaviour, IInteractable
    {
        [SerializeField] protected Transform targetPosition;

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
            OnInteractable(player);
        }

        public virtual void OnInteractable(PlayerController player)
        {
            
        }
    }

}
