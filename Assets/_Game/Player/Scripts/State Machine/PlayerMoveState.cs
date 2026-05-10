using UnityEngine;

namespace Game.Player
{
    public class PlayerMoveState : PlayerBaseState
    {
        public PlayerMoveState(PlayerController player, PlayerStateMachine stateMachine)
        : base(player, stateMachine)
        {
        }

        public override void Enter()
        {
            player.Feedback.ActiveParticleToMove(player.Movement.GetDestination());
        }

        public override void Update()
        {
            player.Animation.SetMoveSpeed(
                player.Movement.GetVelocity()
            );

            if (player.Movement.HasReachedDestination())
            {
                stateMachine.ChangeState(player.IdleState);
            }

            if (player.Input.HasClick)
            {
                player.Movement.MoveTo(
                    player.Input.ClickPosition
                );
                player.Feedback.ActiveParticleToMove(player.Movement.GetDestination());
            }
        }
    }

}

