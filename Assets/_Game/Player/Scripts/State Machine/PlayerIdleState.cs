using UnityEngine;

namespace Game.Player
{
    public class PlayerIdleState : PlayerBaseState
    {
        public PlayerIdleState(PlayerController player, PlayerStateMachine stateMachine)
        : base(player, stateMachine)
        {
        }

        public override void Update()
        {

            if (player.Input.HasClick)
            {
                player.Movement.MoveTo(
                    player.Input.ClickPosition
                );

                stateMachine.ChangeState(player.MoveState);
            }

            if (!player.Input.HasClick)
                return;

            // INTERACTION
            if (player.Input.CurrentInteractable != null)
            {
                player.InteractState.SetInteractable(
                    player.Input.CurrentInteractable
                );

                stateMachine.ChangeState(
                    player.InteractState
                );

                return;
            }

            // MOVE
            player.Movement.MoveTo(
                player.Input.ClickPosition
            );

            stateMachine.ChangeState(
                player.MoveState
            );
        }
    }
}

