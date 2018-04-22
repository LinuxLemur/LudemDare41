using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loadout : MonoBehaviour
{
	[SerializeField]
	private List<Card> SelectedDeck;

	public void ClearLoadOut()
	{
		while (SelectedDeck.Count > 0)
		{
			for (int i = 0; i < SelectedDeck.Count; i++)
			{
				SelectedDeck.RemoveAt(i);
			}
		}

	}
	
	public void setCards()
	{		
		var cards = GameObject.FindObjectOfType<CardManager>();

		cards.cardPrefabs = SelectedDeck;
	}

	public void AddToLoadout(GameObject cardtoadd)
	{
		var card = cardtoadd.GetComponent<Card>();
		
		if (card != null)
		{
			if(SelectedDeck.Count >= 15)
			{
				Debug.LogWarning("DECK IS FULL");
				return;
				
			}
			SelectedDeck.Add(card);
		}
	}

}
