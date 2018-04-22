using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSystem", menuName = "PlayerSystem")]
internal sealed class PlayerSystem : ScriptableObject
{
    [SerializeField] private float health;

    [SerializeField] private float attackDelay;

    [SerializeField] private float damage;

    [SerializeField] private float movementSpeed;

    private float MaxDamage = 3, defaultdamage = 1;
    private float attackcoolddown = 0.2f, _minattackspeed = 0.1f;
    private float defaultHealth = 100, maxHealth = 100;
    private float defaultMovementspeed = 10, MaxMovespeed = 15;


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

        set { this.attackDelay = Mathf.Clamp(value, this._minattackspeed, 3); }
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
        Debug.Log("Resetting stats.");
        this.health = this.defaultHealth;
        this.attackDelay = attackcoolddown;
        this.damage = defaultdamage;
        this.movementSpeed = defaultMovementspeed;
        attackDelay = 0.2f;;
    }
}