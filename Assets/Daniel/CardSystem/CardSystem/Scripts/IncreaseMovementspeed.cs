using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "IncreaseMovementspeed", menuName = "IncreaseMovementspeed")]
internal sealed class IncreaseMovementspeed : Ability 
{
    [SerializeField]
    private PlayerSystem playersystem;

    [SerializeField] private float amount;
    
    public override void Activate()
    {
        this.playersystem.MovementSpeed += amount;
    }
}
