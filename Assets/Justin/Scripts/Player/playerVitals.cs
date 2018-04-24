using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
		SceneManager.LoadScene("scene_Menu");
		//Destroy (this.gameObject);
	}
}