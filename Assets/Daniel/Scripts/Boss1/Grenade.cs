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
    
    [SerializeField] private AudioSource exposionsource;
    [SerializeField] private AudioClip explosionsound;
    [SerializeField] private GameObject Explosion;

    void Start()
    {
        exposionsource = gameObject.GetComponent<AudioSource>();
        _countDown = delay;

        var indicator = Instantiate(IndicatorObject);
        indicator.transform.localScale = new Vector3(1, 0.01f, 1);

        indicator.transform.localScale = indicator.transform.localScale * (radius * 2);
        indicator.transform.position = this.transform.position;
        indicator.transform.parent = this.gameObject.transform;
        
        Destroy(indicator, delay);
    }

    private void Awake()
    {
        var projrb = GetComponent<Rigidbody>();
        projrb.AddForce(transform.forward * 250); projrb.AddForce(transform.up * 250); 
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
        exposionsource.PlayOneShot(explosionsound);
        var explosion = Instantiate(Explosion, this.transform.position, this.transform.rotation);
        explosion.transform.parent = this.transform;
        Collider[] hitObjects = Physics.OverlapSphere(transform.position, radius);
        
        foreach (Collider nearbyObject in hitObjects)
        {
            var _hit = nearbyObject.GetComponent<playerVitals>();

            if (_hit == true)
            {
                _hit.TakeDamage(damage);
            }
        }

        Destroy(this.gameObject, 0.2f);
    }
}