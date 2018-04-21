using UnityEngine;
using UnityEngine.AI;

namespace Dnaiel.Scripts
{
    public class Enemy : MonoBehaviour
    {

        private NavMeshAgent _agent;
        private Transform _target;
        
        [SerializeField] private float _speed;


        private void Awake()
        {
            _agent = gameObject.GetComponent<NavMeshAgent>();
            _agent.speed = _speed;
        }

        private void Update()
        {
            if(_agent == null) return;
            
            _agent.SetDestination(_target.position);
        }
    }
}