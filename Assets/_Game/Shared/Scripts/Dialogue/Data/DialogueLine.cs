using System;
using UnityEngine;

namespace Game.Shared.Dialogue
{
    [Serializable]
    public class DialogueLine
    {
        [TextArea(3, 8)]
        public string Text;

        public CharacterDialogueData Character;
    }
}

