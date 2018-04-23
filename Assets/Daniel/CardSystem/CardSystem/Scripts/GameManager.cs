using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

	[SerializeField] private PlayerSystem system;
	private CardManager _cards;

	private void OnEnable ()
	{
		_cards = this.GetComponent<CardManager> ();
	}

	private void Update ()
	{
		if (Input.GetKeyDown (KeyCode.M))
		{
			_cards.ResetDeck ();
		}

		if (Input.GetKeyDown (KeyCode.N))
		{
			system.ResetStats ();
		}
	}
}