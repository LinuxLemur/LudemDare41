using UnityEngine;
using UnityEngine.AI;

namespace Dnaiel.Scripts
{
    public class Enemy : MonoBehaviour
    {
        private NavMeshAgent _agent;
        [SerializeField] private Transform _target;
        [SerializeField] private GameObject _bullet;
        [SerializeField] private Transform _firePoint;
        [SerializeField] private float _speed;

        private const float StoppingDistance = 10;
        private float _dist;
        private float shotcooldown = 1;
        private float _currentshotcooldown;


        private void Awake()
        {
            _agent = gameObject.GetComponent<NavMeshAgent>();
            _agent.speed = _speed;
            _agent.stoppingDistance = StoppingDistance;
        }

        private void Update()
        {
            EnemyMovement();

            _currentshotcooldown -= Time.deltaTime;

            if (_dist <= 10)
            {
                _agent.velocity = Vector3.zero;
                
                if(_currentshotcooldown > 0) return;

                _currentshotcooldown = shotcooldown;
                
                FireWeapon();
                
            }
        }

        private void EnemyMovement()
        {
            if (_agent == null) return;

            _dist = Vector3.Distance(_target.position, gameObject.transform.position);

            _agent.SetDestination(_target.position);
        }

        private void FireWeapon()
        {
           var spawnedBullet =  Instantiate(_bullet, _firePoint.transform.position, _firePoint.transform.rotation);
            Destroy(spawnedBullet, 2);
        }
    }
}