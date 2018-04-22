using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    [SerializeField] private PlayerSystem _playerstats;

    [SerializeField] private float _movespeed;

    [SerializeField] private float _damage;

    [SerializeField] private float _attackDelay;

    
    private void Update()
    {
        _movespeed = _playerstats.MovementSpeed;
        _damage = _playerstats.Damage;
        _attackDelay = _playerstats.AttackSpeed;
    }
}