using Game.Shared.Dialogue;

namespace Game.Player
{
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

