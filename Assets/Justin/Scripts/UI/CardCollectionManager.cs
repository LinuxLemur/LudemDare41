using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Justin
{
	public class CardCollectionManager : MonoBehaviour
	{
		private GameObject currentCardSlot;
		[SerializeField] Loadout loadout;

		[Header ("Panels")]
		[SerializeField] private GameObject pnlStash;
		[SerializeField] private GameObject pnlDeck;
		[SerializeField] private GameObject pnlCollection;

		[Header ("Images")]
		[SerializeField] private Sprite emptySlotSprite;

		private LockedSlot slottolock;

		private void Awake ()
		{
			pnlStash.SetActive (true);
			pnlDeck.SetActive (true);
			pnlCollection.SetActive (false);

		}

		public void searchCollection () //is called when clicking on an empty slot is the deck
		{	
			currentCardSlot = EventSystem.current.currentSelectedGameObject; //the GameObject that was clicked on (the empty slot that was clicked on)
			slottolock = currentCardSlot.GetComponent<LockedSlot> ();
			if (slottolock.isslotlocked == true) return;
			showCollection ();
		}

		public void addToDeck () //is called when clicking on a card in your collection
		{
			if (loadout.currentdecksize >= loadout.maxDeckSize) return;

			var card = EventSystem.current.currentSelectedGameObject.GetComponent<Image> (); //the Card component on the card selected from the deck

			slottolock.isslotlocked = true;

			var slotPos = currentCardSlot.transform.position;
			var slotRot = currentCardSlot.transform.rotation;
			var TargetImage = currentCardSlot.gameObject.GetComponent<Image> ();
			var FetchedImage = card.GetComponent<Image> ();

			TargetImage.sprite = FetchedImage.sprite;

			showDeck ();
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
		public void ClearDeck ()
		{

			var deckSlots = GameObject.Find ("Deck Slots").transform;
			loadout.currentdecksize = 0;

			foreach (Transform child in deckSlots)
			{
				var imagetoset = child.GetComponent<Image> ();
				var turnoflock = child.GetComponent<LockedSlot>();
				turnoflock.isslotlocked = false;
				Debug.Log (imagetoset);
				imagetoset.sprite = emptySlotSprite;
			}

		}

	}
}