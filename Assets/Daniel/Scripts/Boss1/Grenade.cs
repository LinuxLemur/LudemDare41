using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField]
    private float delay = 3f;
    [SerializeField]
    private float radius;
    [SerializeField]
    private int damage;
    private float force = 700;
    public GameObject IndicatorObject;

    private float _countDown;
    private bool _hasExploded = false;

    void Start()
    {
        _countDown = delay;

        var indicator = Instantiate(IndicatorObject);
        indicator.transform.localScale = new Vector3(1, 0.01f, 1);

        indicator.transform.localScale = indicator.transform.localScale * (radius * 2);
        indicator.transform.position = this.transform.position;
        indicator.transform.parent = this.gameObject.transform;
        Destroy(indicator, delay);
    }

    void Update()
    {
        _countDown -= Time.deltaTime;
        if (_countDown <= 0 && !_hasExploded)
        {
            _hasExploded = true;
            Explode();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    void Explode()
    {

        Collider[] hitObjects = Physics.OverlapSphere(transform.position, radius);
        
        foreach (Collider nearbyObject in hitObjects)
        {
            var _hit = nearbyObject.GetComponent<playerVitals>();

            if (_hit == true)
            {
                _hit.TakeDamage(damage);
            }
        }

        Destroy(gameObject);
    }
}