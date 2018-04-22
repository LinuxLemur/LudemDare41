using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TestAbility", menuName = "TestAbility")]
internal sealed class TestAbility : Ability
{
    public GameObject _go;
    
    public override void Activate()
    {
       Instantiate(_go);
    }
}
