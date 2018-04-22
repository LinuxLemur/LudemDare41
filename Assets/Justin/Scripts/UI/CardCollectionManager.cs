using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Justin
{
	public class CardCollectionManager : MonoBehaviour
	{
		[Header ("Panels")]
		[SerializeField] private GameObject pnlStash;
		[SerializeField] private GameObject pnlDeck;
		[SerializeField] private GameObject pnlCollection;
		[SerializeField] private GameObject pnlAddCheck;
		[SerializeField] private GameObject pnlClearCheck;

		private void Awake ()
		{
			pnlStash.SetActive (true);
			pnlDeck.SetActive (true);
			pnlCollection.SetActive (false);
			pnlAddCheck.SetActive (false);
		}

		public void chooseCard1 ()
		{
			showDeck ();
			var selectedCard = EventSystem.current.currentSelectedGameObject;
			// selectedCard.transform.position = 
		}

		public void showCollection ()
		{
			pnlDeck.SetActive (false);
			pnlCollection.SetActive (true);
		}

		public void showDeck ()
		{
			pnlCollection.SetActive (false);
			pnlDeck.SetActive (true);
		}

		public void clearCheck ()
		{
			pnlClearCheck.SetActive (true);

		}

		public void addCheck ()
		{

		}

		public void ClearDeck ()
		{

		}

	}
}