using UnityEngine;

namespace Dnaiel.Scripts
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private int _maxHealth;
        [SerializeField] private int _currentHealth;

        [SerializeField] private PlayerHealthBar _healthBar;

        private void Awake()
        {
            if (_healthBar == null)
            {
                Debug.LogError("No health bar assigned");
                return;
            }

            _currentHealth = _maxHealth;
            _healthBar.Maxhealth = _maxHealth;
            _healthBar.CurrentHealth = _currentHealth;
        }

        public void TakeDamage(int damageRecivied)
        {
            _currentHealth -= damageRecivied;
            _healthBar.Maxhealth = _maxHealth;
            _healthBar.CurrentHealth = _currentHealth;
            
            if (_currentHealth < 0)
                _currentHealth = 0;

            _healthBar.UpdateHealthBar();
        }
    }
}