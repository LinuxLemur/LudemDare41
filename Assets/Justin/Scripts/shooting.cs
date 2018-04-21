using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Justin
{
	public class shooting : MonoBehaviour
{
	[SerializeField] private int bulletSpeed = 10;
	[SerializeField] private GameObject bullet;
	[SerializeField] private GameObject bulletSpawn;
	[SerializeField] private float shotCooldown;
	[SerializeField] private float currentShotCooldown;

	private void Awake ()
	{
		currentShotCooldown = shotCooldown;
		if (bulletSpawn == null)
		{
			Debug.LogError ("No fire point assigned");
			return;
		}
	}

	void Update ()
	{
		currentShotCooldown -= Time.deltaTime;
		listenForInput ();
	}

	void listenForInput ()
	{
		if (currentShotCooldown > 0) return;

		if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.RightArrow))
			shoot ();
	}

	void shoot ()
	{
		currentShotCooldown = shotCooldown;
		var spawnedBullet = Instantiate (bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
		var rbBullet = spawnedBullet.gameObject.GetComponent<Rigidbody> ();
		rbBullet.AddForce (transform.forward * (bulletSpeed * 50));
	}
}
}
