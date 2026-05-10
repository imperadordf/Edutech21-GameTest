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

}

