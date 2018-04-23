using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerVitals : MonoBehaviour
{
	[SerializeField] private PlayerSystem _playerSystem;

	public void TakeDamage (int damageReceived)
	{
		_playerSystem.Health -= damageReceived;
		if (_playerSystem.Health <= 0)
			Death ();
	}

	void Death ()
	{
		Destroy (this.gameObject);
	}
}