using Game.Shared.Dialogue;
using Game.Shared.Interactable;
using UnityEngine;

namespace Game.Player
{
    public class PlayerInteractState : PlayerBaseState
    {
        private IInteractable interactable;

        public PlayerInteractState(
            PlayerController player,
            PlayerStateMachine stateMachine
        ) : base(player, stateMachine)
        {
        }

        public void SetInteractable(IInteractable interactable)
        {
            this.interactable = interactable;
        }

        public override void Enter()
        {
            player.Movement.MoveTo(
                interactable.GetTransform().position
            );
        }

        public override void Update()
        {
            player.Animation.SetMoveSpeed(
                player.Movement.GetVelocity()
            );

            if (player.Movement.HasReachedDestination())
            {
                stateMachine.ChangeState(player.IdleState);
                interactable.Interact(player);
            }
        }
    }


    public class PlayerInteractDialogue : PlayerBaseState
    {
        private DialogueController _dialogueController;

        private bool _finishedDialogue = true;

        private DialogueData dialogue;

        public bool InDialogue { get; private set; }

        public PlayerInteractDialogue(
            PlayerController player,
            PlayerStateMachine stateMachine,
            DialogueController dialogueController
        ) : base(player, stateMachine)
        {
            _dialogueController = dialogueController;
        }

        public void SetDialogue(DialogueData dialogueData)
        {
            dialogue = dialogueData;
            _finishedDialogue = false;
        }

        public override void Enter()
        {
            InDialogue = true;
            _dialogueController.StartDialogue(dialogue, () =>
           {
               _finishedDialogue = true;
           });
        }

        public override void Update()
        {
            player.Input.EnabledInput = false;
            if (_finishedDialogue)
            {
                stateMachine.ChangeState(player.IdleState);
            }
        }

        public override void Exit()
        {
            base.Exit();
            dialogue = null;
            InDialogue = false;
            player.Input.EnabledInput = true;
        }
    }

}

