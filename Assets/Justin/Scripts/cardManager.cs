using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Justin
{
	public class cardManager : MonoBehaviour
	{
		private abilityManager abilityManager;
		[SerializeField] private List<GameObject> unusedCards;

		[SerializeField] private List<GameObject> usedCards;

		public GameObject selectedCard;

		private void Awake ()
		{
			abilityManager = gameObject.GetComponent<abilityManager> ();
		}

		private void Update ()
		{
			if (Input.GetKeyDown (KeyCode.Tab))
			{
				addAbility ();
			}

			if (unusedCards.Count <= 0)
			{
				foreach (var card in usedCards)
				{
					unusedCards.Add(card);
				}

				usedCards = null;
			}
		}

		public void addAbility ()
		{
			if (abilityManager.ability1 == null)
			{
				abilityManager = gameObject.GetComponent<abilityManager> ();
				selectedCard = unusedCards[Random.Range (0, unusedCards.Count)];
				unusedCards.Remove (selectedCard);
				usedCards.Add (selectedCard);
				if (abilityManager.ability1 == null)
					abilityManager.ability1 = selectedCard;
				selectedCard = null;
				return;
			}

			if (abilityManager.ability2 == null)
			{
				abilityManager = gameObject.GetComponent<abilityManager> ();
				selectedCard = unusedCards[Random.Range (0, unusedCards.Count)];
				unusedCards.Remove (selectedCard);
				usedCards.Add (selectedCard);
				if (abilityManager.ability2 == null)
					abilityManager.ability2 = selectedCard;
				selectedCard = null;
				return;
			}

			if (abilityManager.ability3 == null)
			{
				abilityManager = gameObject.GetComponent<abilityManager> ();
				selectedCard = unusedCards[Random.Range (0, unusedCards.Count)];
				unusedCards.Remove (selectedCard);
				usedCards.Add (selectedCard);
				if (abilityManager.ability3 == null)
					abilityManager.ability3 = selectedCard;
				selectedCard = null;
				return;
			}

			return;

		}
	}
}