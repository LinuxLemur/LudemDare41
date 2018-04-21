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
				ability1 = null;
			}

			if (Input.GetKeyDown (KeyCode.E))
			{
				ability2 = null;
			}

			if (Input.GetKeyDown (KeyCode.R))
			{
				ability3 = null;
			}
		}

	}

}