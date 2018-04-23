using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
	[SerializeField] private float health;

	public void TakeDamage (float damageTaken)
	{
		health -= damageTaken;
		if (health <= 0)
			DestroyGameObject ();
	}

	private void DestroyGameObject ()
	{
		Destroy(this.gameObject);
	}
}