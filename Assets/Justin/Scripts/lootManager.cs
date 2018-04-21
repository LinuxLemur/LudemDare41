using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Justin
{
	public enum enemyType { normal, boss }

	public class lootManager : MonoBehaviour
	{
		public enemyType _enemy;

		[Header ("Drag & Drop Objects")]
		[SerializeField] private GameObject health;
		[SerializeField] private GameObject card;

		[Header ("Debugging Variables")]
		[SerializeField] private int nothings;
		[SerializeField] private int healths;
		[SerializeField] private int cards;
		[SerializeField] private int total;

		void Update ()
		{
			if (Input.GetKeyDown (KeyCode.Space))  //chooseLootTable will be called on enemyDeath
			{
				chooseLootTable ();
			}
		}

		void chooseLootTable ()
		{
			if (_enemy == enemyType.normal)
				normalLoot ();
			else
				bossLoot ();
		}

		void bossLoot ()
		{
			var randomNumber = Random.Range (1, 101);

			if (randomNumber >= 50) //50% chance
				dropCard ();
			else if (randomNumber >= 15) //35% chance
				dropHealth ();
			else if (randomNumber >= 1) //15% chance
				dropNothing ();
		}

		void normalLoot ()
		{
			var randomNumber = Random.Range (1, 101);

			if (randomNumber >= 90) //10% chance
				dropCard ();
			else if (randomNumber >= 60) //30% chance
				dropHealth ();
			else if (randomNumber >= 1) //60% chance
				dropNothing ();
		}

		void dropCard ()
		{
			var dropPos = new Vector3 (1, 1, 0); // will get deathPos from enemyDeath
			Instantiate (card, dropPos, transform.rotation);

			cards++;
			total++;
		}

		void dropHealth ()
		{
			var dropPos = new Vector3 (0, 1, 0); // will get deathPos from enemyDeath
			Instantiate (health, dropPos, transform.rotation);

			healths++;
			total++;
		}

		void dropNothing ()
		{
			nothings++;
			total++;
		}
	}
}