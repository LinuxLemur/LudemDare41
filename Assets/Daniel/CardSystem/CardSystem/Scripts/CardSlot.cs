using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
internal sealed class CardSlot : MonoBehaviour, IPointerDownHandler
{
    private Image image;

    [SerializeField]
    private KeyCode boundKey;

    [SerializeField]
    private Sprite defaultSprite;

    private Card card;
    
    public Card Card
    {
        get
        {
            return this.card;
        }

        set
        {
            this.card = value;
            this.image.sprite = this.card != null ? this.card.Sprite : this.defaultSprite;
        }
    }

    private void Awake()
    {
        this.image = this.GetComponent<Image>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(this.boundKey))
        {
            this.Click();
        }
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        this.Click();
    }

    private void Click()
    {
        if (this.Card == null)
        {
            Debug.LogWarning("Cannot activate ability, card is null.");
            return;
        }
        
        this.Card.Ability.Activate();
        
        this.Card = null;
    }
}
