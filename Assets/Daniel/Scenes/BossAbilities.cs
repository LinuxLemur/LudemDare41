using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BossAbilities : ScriptableObject
{
    public float maxCooldown;
    public float currentCooldown;
    public GameObject _objectToThrow;

    private void OnEnable()
    {
        currentCooldown = maxCooldown;
    }

    public void Activate(Transform[] firepoint)
    {
        currentCooldown -= Time.deltaTime;

        if (currentCooldown <= 0)
        {
            currentCooldown = maxCooldown;

            for (int i = 0; i < firepoint.Length; i++)
            {
                Instantiate(_objectToThrow, firepoint[i].transform.position, firepoint[i].transform.rotation);
            }
        }
    }

    private void OnDisable()
    {
        currentCooldown = maxCooldown;
    }
}