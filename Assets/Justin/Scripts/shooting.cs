﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Justin
{
	public class shooting : MonoBehaviour
	{
		[Header ("Shooting Properties")]
		[SerializeField] private int bulletSpeed = 10;
		[SerializeField] private float fireDelay = 1f;
		private float currentShotCooldown;

		[Header ("Drag & Drop")]
		[SerializeField] private GameObject bullet;
		[SerializeField] private GameObject[] bulletSpawns;

		private void Awake ()
		{
			currentShotCooldown = fireDelay;

			if (bulletSpawns == null)
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
			currentShotCooldown = fireDelay;
			for (int i = 0; i < bulletSpawns.Length; i++)
			{
				var spawnedBullet = Instantiate (bullet, bulletSpawns[i].transform.position, bulletSpawns[i].transform.rotation);
				var rbBullet = spawnedBullet.gameObject.GetComponent<Rigidbody> ();
				rbBullet.AddForce (transform.forward * (bulletSpeed * 50));
			}

		}
	}
}