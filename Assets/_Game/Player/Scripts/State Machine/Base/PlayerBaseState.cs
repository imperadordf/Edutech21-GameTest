namespace Game.Player
{
    public abstract class PlayerBaseState
    {
        protected PlayerController player;
        protected PlayerStateMachine stateMachine;

        public PlayerBaseState(PlayerController player, PlayerStateMachine stateMachine)
        {
            this.player = player;
            this.stateMachine = stateMachine;
        }

        public virtual void Enter() { }
        public virtual void Exit() { }

        public virtual void Update() { }
        public virtual void FixedUpdate() { }
    }
}

