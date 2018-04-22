using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSystem", menuName = "PlayerSystem")]
internal sealed class PlayerSystem : ScriptableObject
{
    [Header("Current Values")] [SerializeField]
    private float health;

    [SerializeField] private float attackDelay;
    [SerializeField] private float damage;
    [SerializeField] private float movementSpeed;

    [Header("Default Values")] [SerializeField]
    private float defaultdamage = 0;

    [SerializeField] private float attackcoolddown = 0.1f;
    [SerializeField] private float defaultHealth = 100;
    [SerializeField] private float defaultMovementspeed = 15;

    [Header("Max Values")] [SerializeField]
    private float MaxDamage = 3;

    [SerializeField] private float _minattackspeed = 0.0f;
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private float MaxMovespeed = 15;

    public float Damage
    {
        get { return this.damage; }

        set { this.damage = Mathf.Clamp(value, 0f, this.MaxDamage); }
    }

    public float Health
    {
        get { return this.health; }

        set { this.health = Mathf.Clamp(value, 0f, this.maxHealth); }
    }

    public float AttackSpeed
    {
        get { return this.attackDelay; }

        set { this.attackDelay = Mathf.Clamp(value, this._minattackspeed, 1); }
    }

    public float MovementSpeed
    {
        get { return this.movementSpeed; }
        set { this.movementSpeed = Mathf.Clamp(value, 1f, this.MaxMovespeed); }
    }


    private void OnEnable()
    {
        ResetStats();
    }

    public void ResetStats()
    {
        health = defaultHealth;
        attackDelay = attackcoolddown;
        damage = defaultdamage;
        movementSpeed = defaultMovementspeed;
        Debug.Log("Resetting stats.");
    }
}