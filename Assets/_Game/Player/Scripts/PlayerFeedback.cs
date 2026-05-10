using UnityEngine;

namespace Game.Player
{
    public class PlayerFeedback: MonoBehaviour
    {
        [SerializeField] private ParticleSystem particleSystemMove;

        void Awake()
        {
            particleSystemMove.transform.SetParent(null);
        }

        public void ActiveParticleToMove(Vector3 position)
        {
            if (particleSystemMove.isPlaying)
            {
                particleSystemMove.Stop();
            }
            
            particleSystemMove.transform.position = position;
            particleSystemMove.Play();
        }
    }
}

