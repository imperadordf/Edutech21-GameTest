using Game.Player;
using UnityEngine;

namespace Game.Shared.Interactable
{
    public interface IInteractable
    {
        public bool Interactable{get;set;}
        Transform GetTransform();

        void Interact(PlayerController player);
    }
}

