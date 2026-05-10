using Game.Player;
using UnityEngine;

namespace Game.Shared.Interactable
{
    public interface IInteractable
    {
        Transform GetTransform();

        void Interact(PlayerController player);
    }
}

