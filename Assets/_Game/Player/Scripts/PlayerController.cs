using Game.Shared.Dialogue;
using UnityEngine;

namespace Game.Player
{
    public class PlayerController : MonoBehaviour
    {
        public DialogueController dialogueController;

        public PlayerMovement Movement { get; private set; }
        public PlayerAnimation Animation { get; private set; }
        public PlayerInputHandler Input { get; private set; }
        public PlayerFeedback Feedback { get; private set; }


        public PlayerStateMachine StateMachine;

        public PlayerIdleState IdleState;
        public PlayerMoveState MoveState;
        public PlayerInteractState InteractState;
        public PlayerInteractDialogue DialogueState;

        private void Awake()
        {
            Movement = GetComponent<PlayerMovement>();
            Animation = GetComponent<PlayerAnimation>();
            Input = GetComponent<PlayerInputHandler>();
            Feedback = GetComponent<PlayerFeedback>();

            StateMachine = new PlayerStateMachine();

            IdleState = new PlayerIdleState(this, StateMachine);
            MoveState = new PlayerMoveState(this, StateMachine);
            InteractState = new PlayerInteractState(this, StateMachine);
            DialogueState = new PlayerInteractDialogue(this,StateMachine,dialogueController);
        }

        private void Start()
        {
            StateMachine.Initialize(IdleState);
        }

        private void Update()
        {
            StateMachine.Update();
        }

        private void FixedUpdate()
        {
            StateMachine.FixedUpdate();
        }
    }
}

