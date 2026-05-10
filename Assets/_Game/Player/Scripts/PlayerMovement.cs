using UnityEngine;
using UnityEngine.AI;

namespace Game.Player
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent agent;

        public void MoveTo(Vector3 position)
        {
            agent.SetDestination(position);
        }

        public bool HasReachedDestination()
        {
            if (agent.pathPending)
                return false;

            return agent.remainingDistance <= agent.stoppingDistance;
        }

        public float GetVelocity()
        {
            return agent.velocity.magnitude;
        }

        public Vector3 GetDestination()
        {
            return agent.destination;
        }
    }
}

