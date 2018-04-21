using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Justin
{
	public class abilityManager : MonoBehaviour
	{
		[SerializeField] private GameObject currentAbility;

		public GameObject ability1;
		public GameObject ability2;
		public GameObject ability3;

		private void Awake ()
		{

		}

		private void Update ()
		{
			if (Input.GetKeyDown (KeyCode.Q))
			{
				Destroy(ability1);
			}

			if (Input.GetKeyDown (KeyCode.E))
			{
				Destroy(ability2);
			}

			if (Input.GetKeyDown (KeyCode.R))
			{
				Destroy(ability3);
			}
		}

	}

}