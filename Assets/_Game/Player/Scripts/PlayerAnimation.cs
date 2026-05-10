using UnityEngine;

namespace Game.Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        private static readonly int MoveSpeed = Animator.StringToHash("MoveSpeed");

        public void SetMoveSpeed(float value)
        {
            animator.SetFloat(MoveSpeed, value);
        }
    }
}

