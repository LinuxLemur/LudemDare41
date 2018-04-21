using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Justin
{
	public class playerMovement : MonoBehaviour
	{
		private GameObject player;
		[SerializeField]
		private int speed = 10;

		private void Start ()
		{
			player = this.gameObject;
		}

		void Update ()
		{
			move ();
		}

		public void move ()
		{
			Vector3 Movement = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));

			player.transform.position += Movement * speed * Time.deltaTime;
		}

	}
}