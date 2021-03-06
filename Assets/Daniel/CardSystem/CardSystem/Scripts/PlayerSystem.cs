﻿using System;
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

    [SerializeField] private float firedelay = 0.1f;
    [SerializeField] private float defaultHealth = 100;
    [SerializeField] private float defaultMovementspeed = 15;

    [Header("Max Values")] [SerializeField]
    private float MaxDamage = 3;

    [SerializeField] public float _minFireDelay = 0.0f;
    [SerializeField] public float maxHealth = 100;
    [SerializeField] public float MaxMovespeed = 15;

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

    public float fireDelay
    {
        get { return this.attackDelay; }

        set { this.attackDelay = Mathf.Clamp(value, this._minFireDelay, 1); }
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
        attackDelay = firedelay;
        damage = defaultdamage;
        movementSpeed = defaultMovementspeed;
        Debug.Log("Resetting stats.");
    }
}