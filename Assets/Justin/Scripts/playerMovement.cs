using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Justin
{
	public class playerMovement : MonoBehaviour
	{
		[SerializeField] private PlayerSystem playerSystem; 
		private GameObject player;

		private void Start ()
		{
			player = this.gameObject;
		}

		void Update ()
		{
			move ();
			rotate ();
		}

		public void move ()
		{
			Vector3 Movement = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));
			player.transform.position += Movement.normalized * playerSystem.MovementSpeed * Time.deltaTime;			
		}

		public void rotate ()
		{
			if (Input.GetKey (KeyCode.RightArrow))			
				player.transform.rotation = Quaternion.Euler(0,90,0);
			
			if (Input.GetKey (KeyCode.LeftArrow))			
				player.transform.rotation = Quaternion.Euler(0,-90,0);

			if (Input.GetKey (KeyCode.UpArrow))			
				player.transform.rotation = Quaternion.Euler(0,0,0);
			
			if (Input.GetKey (KeyCode.DownArrow))			
				player.transform.rotation = Quaternion.Euler(0,180,0);

			// ↓ 8 way aiming ↓

			if (Input.GetKey (KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow))			
				player.transform.rotation = Quaternion.Euler(0,-135,0);

			if (Input.GetKey (KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow))			
				player.transform.rotation = Quaternion.Euler(0,135,0);

			if (Input.GetKey (KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow))			
				player.transform.rotation = Quaternion.Euler(0,-45,0);

			if (Input.GetKey (KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow))			
				player.transform.rotation = Quaternion.Euler(0,45,0);
		}

	}
}