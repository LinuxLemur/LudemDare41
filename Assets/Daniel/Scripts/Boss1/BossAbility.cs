using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Internal.Execution;
using UnityEngine;

public class BossAbility : MonoBehaviour
{

    public GameObject _objectToThrow;
    [SerializeField] private Transform[] firepoint;

    private bool hasspwnedl;

    private float currentcountdown;
    [SerializeField]private float cooldownvalue;

    private void Update()
    {
        currentcountdown -= Time.deltaTime;
        
        if (currentcountdown <= 0)
        {
            currentcountdown = cooldownvalue;
            for (int i = 0; i < firepoint.Length; i++)
            {
                var insttiatedproj = Instantiate(_objectToThrow, firepoint[i].transform.position, firepoint[i].transform.rotation);
                var projrb = insttiatedproj.GetComponent<Rigidbody>();
        
                projrb.AddForce(firepoint[i].transform.forward * 250); projrb.AddForce(firepoint[i].transform.up * 250); 
            }

        } 

    }
}
