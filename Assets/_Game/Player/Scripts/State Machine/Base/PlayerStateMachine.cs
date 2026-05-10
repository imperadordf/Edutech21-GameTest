namespace Game.Player
{
    public class PlayerStateMachine
    {
        public PlayerBaseState CurrentState { get; private set; }

        public void Initialize(PlayerBaseState state)
        {
            CurrentState = state;
            state.Enter();
        }

        public void ChangeState(PlayerBaseState newState)
        {
            CurrentState?.Exit();

            CurrentState = newState;

            CurrentState.Enter();
        }

        public void Update()
        {
            CurrentState?.Update();
        }

        public void FixedUpdate()
        {
            CurrentState?.FixedUpdate();
        }
    }
}

