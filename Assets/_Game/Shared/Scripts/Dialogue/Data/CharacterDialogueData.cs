using UnityEngine;

namespace Game.Shared.Dialogue
{
    [CreateAssetMenu(fileName = "CharacterDialogueData", menuName = "Dialogue/Character Data")]
    public class CharacterDialogueData : ScriptableObject
    {
        [Header("Character Info")]
        public string CharacterName;
        public Sprite CharacterIcon;
    }
}

