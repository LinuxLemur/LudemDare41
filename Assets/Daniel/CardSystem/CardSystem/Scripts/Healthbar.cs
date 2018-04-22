using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
internal sealed class Healthbar : MonoBehaviour
{
    private Image image;

    [SerializeField]
    private PlayerSystem _playerSystem;

    private void Awake()
    {
        this.image = this.GetComponent<Image>();
    }

    private void OnEnable()
    {
      //  this.healthSystem.HealthChanged += this.OnHealthChanged;
    }

    private void OnDisable()
    {
//        this.healthSystem.HealthChanged -= this.OnHealthChanged;
    }

    private void OnHealthChanged(float health)
    {
    //    this.image.fillAmount = health / this._playerSystem.MaxHealth;
    }
}
