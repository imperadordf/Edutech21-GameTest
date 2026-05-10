using System.Collections.Generic;
using UnityEngine;

namespace Game.Shared.Dialogue
{
    [CreateAssetMenu(fileName = "NewDialogue", menuName = "Dialogue/Dialogue Data")]
    public class DialogueData : ScriptableObject
    {
        [Header("Dialogue Lines")]
        public List<DialogueLine> Lines = new();
    }
}

