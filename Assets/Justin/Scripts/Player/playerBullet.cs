using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBullet : MonoBehaviour
{
	[SerializeField] private PlayerSystem _playerSystem;

	private void OnCollisionEnter (Collision other)
	{
		if (other.gameObject.tag == "Enemy")
		{
			var enemyhealth = other.gameObject.GetComponent<enemyHealth>();
			enemyhealth.TakeDamage(_playerSystem.Damage);
		}
	}

}