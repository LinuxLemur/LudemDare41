using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Justin
{
	public class PlayerShooting : MonoBehaviour
	{
		[Header ("Shooting Properties")]
		[SerializeField] private PlayerSystem _playerSystem;
		[SerializeField] private int bulletSpeed = 5;
		// [SerializeField] private float fireDelay = .5f;
		private float currentShotCooldown;

		[Header ("Drag & Drop")]
		[SerializeField] private GameObject bullet;
		private GameObject[] bulletSpawns;
		[SerializeField] private GameObject BulletSpawnMain;
		[SerializeField] private GameObject BulletSpawnL;
		[SerializeField] private GameObject BulletSpawnR;

		[SerializeField] private AudioSource gunshotSourcer;
		[SerializeField] private AudioClip gunshot;

		private void Awake ()
		{
			gunshotSourcer = gameObject.GetComponent<AudioSource>();
			currentShotCooldown = _playerSystem.fireDelay;
			FindBulletSpawns ();
			SingleBullet ();
		}

		void Update ()
		{
			currentShotCooldown -= Time.deltaTime;
			listenForInput ();
		}

		void FindBulletSpawns ()
		{
			bulletSpawns = GameObject.FindGameObjectsWithTag ("Bullet Spawn (Player)");

			if (bulletSpawns == null)
			{
				Debug.LogError ("No fire point assigned");
				return;
			}
		}

		void listenForInput ()
		{
			if (currentShotCooldown > 0) return;

			if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.RightArrow))
				shoot ();
		}

		void shoot ()
		{
			gunshotSourcer.PlayOneShot(gunshot);
			currentShotCooldown = _playerSystem.fireDelay;
			for (int i = 0; i < bulletSpawns.Length; i++)
			{
				var spawnedBullet = Instantiate (bullet, bulletSpawns[i].transform.position, bulletSpawns[i].transform.rotation);
				var rbBullet = spawnedBullet.gameObject.GetComponent<Rigidbody> ();
				rbBullet.AddForce (transform.forward * (bulletSpeed * 50));
			}
		}

		public void ActivateVolley ()
		{
			StartCoroutine (MultiBullet ());
		}

		IEnumerator MultiBullet ()
		{
			BulletSpawnMain.SetActive (true);
			BulletSpawnL.SetActive (true);
			BulletSpawnR.SetActive (true);
			FindBulletSpawns ();
			yield return new WaitForSeconds (15f);
			SingleBullet ();
		}

		public void SingleBullet ()
		{
			BulletSpawnMain.SetActive (true);
			BulletSpawnL.SetActive (false);
			BulletSpawnR.SetActive (false);
			FindBulletSpawns ();
		}
	}
}