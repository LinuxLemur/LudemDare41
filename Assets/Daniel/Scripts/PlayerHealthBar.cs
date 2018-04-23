using System.Collections;
using System.Collections.Generic;
using Dnaiel.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Image CurrentHealthBar;

    public float CurrentHealth;
    public float Maxhealth;

    [SerializeField] private PlayerSystem _playerSystem;

    private void Awake ()
    {
        if (CurrentHealthBar == null)
        {
            Debug.LogError ("Health Bar Image not assigned");
        }
    }

    private void Update ()
    {
        CurrentHealth = _playerSystem.Health;
        Maxhealth = _playerSystem.maxHealth;
        UpdateHealthBar();
    }

    public void UpdateHealthBar ()
    {
        var ratio = CurrentHealth / Maxhealth;

        if (ratio < 0)
            ratio = 0;

        CurrentHealthBar.rectTransform.localScale = new Vector3 (ratio, 1, 1);
    }
}