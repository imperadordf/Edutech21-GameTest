using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Shared.Dialogue
{
    public class UIDialogueController : UIMenu
    {
        [Header("UI")]
        [SerializeField] private Image characterIcon;
        [SerializeField] private TextMeshProUGUI characterName;
        [SerializeField] private TextMeshProUGUI dialogueText;

        [SerializeField] private Button buttonNextLine;

        public void Initialize(Action OnNextLine)
        {
            buttonNextLine.onClick.AddListener(() =>
            {
                OnNextLine?.Invoke();
            });
        }

        public void ShowCurrentLine(DialogueLine line)
        {
            SetActiveMenu(true);
            characterName.text = line.Character.CharacterName;
            characterIcon.sprite = line.Character.CharacterIcon;
            dialogueText.text = line.Text;
        }

        public void EndDialogue()
        {
            SetActiveMenu(false);
        }

        protected override void ActiveCanvasGroup(bool active)
        {
            base.ActiveCanvasGroup(active);
        }
    }
}

