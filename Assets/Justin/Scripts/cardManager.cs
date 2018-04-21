using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Justin
{
	public class cardManager : MonoBehaviour
	{
		private abilityManager abilityManager;
		[SerializeField] private List<GameObject> cardStack;

		[SerializeField] private List<GameObject> usedCards;

		private GameObject tempCard;

		private void Awake ()
		{
			abilityManager = gameObject.GetComponent<abilityManager> ();
		}

		private void Update ()
		{
			if (Input.GetKeyDown (KeyCode.Tab))
			{
				getAbilityCard ();
			}

			if (cardStack.Count <= 0)
			{
				shuffleDeck();
			}
		}

		void shuffleDeck ()
		{
			foreach (var card in usedCards)
			{
				usedCards.Remove (card);
				// cardStack.Add (card);								
			}

			 usedCards = null;
			// usedCards.Clear();
		}

		public void getAbilityCard ()
		{
			if (abilityManager.ability1 == null)
			{
				tempCard = cardStack[Random.Range (0, cardStack.Count)];
				cardStack.Remove (tempCard);
				usedCards.Add (tempCard);
				if (abilityManager.ability1 == null)
					abilityManager.ability1 = tempCard;
				tempCard = null;
				return;
			}

			if (abilityManager.ability2 == null)
			{
				tempCard = cardStack[Random.Range (0, cardStack.Count)];
				cardStack.Remove (tempCard);
				usedCards.Add (tempCard);
				if (abilityManager.ability2 == null)
					abilityManager.ability2 = tempCard;
				tempCard = null;
				return;
			}

			if (abilityManager.ability3 == null)
			{
				tempCard = cardStack[Random.Range (0, cardStack.Count)];
				cardStack.Remove (tempCard);
				usedCards.Add (tempCard);
				if (abilityManager.ability3 == null)
					abilityManager.ability3 = tempCard;
				tempCard = null;
				return;
			}

			return;

		}
	}
}