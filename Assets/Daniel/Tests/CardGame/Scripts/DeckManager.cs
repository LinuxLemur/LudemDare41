using System.Linq;
using UnityEngine;

internal sealed class DeckManager : MonoBehaviour
{
    public const int CardCount = 3;

    [SerializeField]
    private CardSlot[] slots = new CardSlot[CardCount];

    private void OnValidate()
    {
        Debug.Assert(this.slots.Length == CardCount, "Incorrect number of cards.");
    }

    public bool Push(Card card)
    {
        for (int i = 0; i < CardCount; i++)
        {
            if (this.slots[i].Card == null)
            {
                this.slots[i].Card = card;
                return true;
            }
        }

        return false;
    }

    public bool Full
    {
        get
        {
            return !this.slots.Any(s => s.Card == null);
        }
    }
}