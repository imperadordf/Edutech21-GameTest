using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Game.Shared.Dialogue
{
    public class DialogueController : MonoBehaviour
    {
        [SerializeField]
        private UIDialogueController uIDialogueController;
        private DialogueData _currentDialogue;
        private int _currentIndex;

        private Action _onFinishDialogue;

        void Awake()
        {
            if (uIDialogueController == null)
                uIDialogueController = GetComponent<UIDialogueController>();

            uIDialogueController.Initialize(NextLine);
        }

        public void StartDialogue(DialogueData dialogue, Action onFinishCallback)
        {
            _currentDialogue = dialogue;
            _currentIndex = 0;

            uIDialogueController.ShowCurrentLine(_currentDialogue.Lines[_currentIndex]);

            _onFinishDialogue = onFinishCallback;
        }

        public void NextLine()
        {
            _currentIndex++;

            if (_currentIndex >= _currentDialogue.Lines.Count)
            {
                EndDialogue();
                return;
            }

            uIDialogueController.ShowCurrentLine(_currentDialogue.Lines[_currentIndex]);
        }

        public void EndDialogue()
        {
            uIDialogueController.EndDialogue();
            _onFinishDialogue?.Invoke();
            _currentDialogue = null;
            _onFinishDialogue = null;
        }

    }
}

