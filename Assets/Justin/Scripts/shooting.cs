﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
	[SerializeField] private int bulletSpeed = 10;
	[SerializeField] private GameObject bullet;
	[SerializeField] private GameObject bulletSpawn;
	[SerializeField] private float shotCooldown;
	[SerializeField] private float currentShotCooldown;

	// Use this for initialization
	private void Awake ()
	{
		currentShotCooldown = shotCooldown;
		if (bulletSpawn == null)
		{
			Debug.LogError ("No fire point assigned");
			return;
		}
	}

	// Update is called once per frame
	void Update ()
	{
		currentShotCooldown -= Time.deltaTime;
		listenForInput ();
	}

	void listenForInput ()
	{
		if (currentShotCooldown > 0) return;
		
		if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.DownArrow))
			shoot ();
		if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.RightArrow))
			shoot ();
	}

	void shoot ()
	{
		currentShotCooldown = shotCooldown;
		var spawnedBullet = Instantiate (bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);

		var rbPlayer = gameObject.GetComponent<Rigidbody>();
		var rbBullet = spawnedBullet.gameObject.GetComponent<Rigidbody> ();
		rbBullet.AddForce (transform.forward * (bulletSpeed * 50));
	}
}