using System;
using System.Collections.Generic;
using UnityEngine;

internal sealed class CardManager : MonoBehaviour
{
    private Stack<Card> unusedCards = new Stack<Card>();

    [SerializeField]
    private Card[] cardPrefabs;
    
    public void ResetDeck()
    {
        this.unusedCards.Clear();
        foreach (var card in this.GetAllCardsShuffled())
        {
            this.unusedCards.Push(card);
        }
    }

    public bool GetUnused(out Card card)
    {
        if (this.unusedCards.Count > 0)
        {
            card = this.unusedCards.Pop();
            return true;
        }

        card = null;
        return false;
    }

    private void Start()
    {
        this.ResetDeck();
    }

    private IEnumerable<Card> GetAllCardsShuffled()
    {
        var cards = new List<Card>(this.cardPrefabs);

        Card[] shuffled = new Card[cards.Count];
        for (int range = cards.Count - 1; range >= 0; range--)
        {
            int i = UnityEngine.Random.Range(0, range);
            shuffled[range] = cards[i];
            cards.RemoveAt(i);
        }

        return shuffled;
    }
}
