using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAbility : MonoBehaviour
{  
    [SerializeField] private Transform[] firepoint;

    public BossAbilities ability;

    private void Update()
    {
       ability.Activate(firepoint);
    }
}
