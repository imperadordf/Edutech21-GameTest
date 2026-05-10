using Game.Player;
using Game.Shared.Dialogue;
using Game.Shared.Interactable;
using UnityEngine;

namespace Game.NPC
{
    public class NPCInteractableDialogue: NPCInteractable, IInteractable
    {
        [SerializeField] private DialogueData dialogueNPC;

        public override void OnInteractable(PlayerController player)
        {
            base.OnInteractable(player);
            player.DialogueState.SetDialogue(dialogueNPC);
            player.StateMachine.ChangeState(player.DialogueState);
        }
    }

}
