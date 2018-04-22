using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


	[SerializeField]private PlayerSystem system;
	[SerializeField] private CardManager _cards;

	private void OnEnable()
	{
		_cards = GameObject.FindObjectOfType<CardManager>();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.M))
		{
			//system.ResetStats();
			_cards.ResetDeck();
		}
		
		if (Input.GetKeyDown(KeyCode.N))
		{
			system.ResetStats();
			//_cards.ResetDeck();
		}
	}
}
