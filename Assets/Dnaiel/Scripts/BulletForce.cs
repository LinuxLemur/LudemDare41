using UnityEngine;

namespace Dnaiel.Scripts
{
    public class BulletForce : MonoBehaviour
    {
        private void Awake()
        {
            var rb = this.gameObject.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 300);
        }
    }
}