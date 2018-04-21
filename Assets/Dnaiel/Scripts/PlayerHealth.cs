using UnityEngine;

namespace Dnaiel.Scripts
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private int _maxHealth;
        private int _currentHealth;

        private void Awake()
        {
            _currentHealth = _maxHealth;
        }

        public void TakeDamage(int damageRecivied)
        {
            _currentHealth -= damageRecivied;

            EventManager.ChangePlayerHealth(_currentHealth);
        }
    }
}