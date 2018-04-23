using UnityEngine;

namespace Daniel.CardSystem.CardSystem.Scripts
{
    [CreateAssetMenu(fileName = "FireNova", menuName = "FireNova")]

    internal sealed class FireNova : Ability
    {
        public GameObject Grenade;
        
        public GameObject IndicatorObject;

        public float radius;

        public int damage;

        public int Pulses = 3;
    
        public override void Activate()
        {
            var playerTransform = GameObject.FindGameObjectWithTag("Player").gameObject.transform;
            
            FireNovaSpawn(playerTransform);
            SpawnIndicator(playerTransform);
        }

        private void FireNovaSpawn(Transform _playerTransform)
        {
            Collider[] hitObjects = Physics.OverlapSphere(_playerTransform.position, radius);
            
            foreach (Collider nearbyObject in hitObjects)
            {
                var _hit = nearbyObject.GetComponent<enemyHealth>();

                if (_hit == true)
                {
                    _hit.TakeDamage(damage);
                }
            }
        }

        private void SpawnIndicator(Transform _playerTransform)
        {
            var indicator = Instantiate(IndicatorObject);
            indicator.transform.localScale = new Vector3(1, 0.01f, 1);
            

            indicator.transform.localScale = indicator.transform.localScale * (radius * 2);
            indicator.transform.position = _playerTransform.position;
            indicator.transform.parent = _playerTransform;
            Destroy(indicator, 0.5f);
        }
    }
}
