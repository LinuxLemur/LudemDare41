using System.Collections;
using System.Collections.Generic;
using Dnaiel.Scripts;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<playerVitals>() != null)
        {
            other.gameObject.GetComponent<playerVitals>().TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}
