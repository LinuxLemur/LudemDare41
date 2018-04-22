using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class DrawButton : MonoBehaviour
{
    private Button button;

    [SerializeField]
    private CardManager cardManager;

    [SerializeField]
    private DeckManager deckManager;

    public float drawtimer = 2f;

    private void Awake()
    {
        this.button = this.GetComponent<Button>();
    }

    private void OnEnable()
    {
        this.button.onClick.AddListener(this.OnDrawClicked);
    }

    private void OnDisable()
    {
        this.button.onClick.RemoveListener(this.OnDrawClicked);
    }

    private void Update()
    {
        drawtimer -= Time.deltaTime;
        if (drawtimer < 0)
        {
            if(deckManager.Full)return;
            
            OnDrawClicked();
            drawtimer = 2;
        }
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (deckManager.Full)
            {
                Debug.LogWarning("Deck was full, couldn't draw card.");
                return;
            }
            OnDrawClicked();
        }
    }

    private void OnDrawClicked()
    {
        Card card;
        
        if (!this.cardManager.GetUnused(out card))
        {
            Debug.LogWarning("No unused cards, couldn't draw card.");
            return;
        }

        if (this.deckManager.Push(card))
        {
            Debug.Log("Drew card.");
        }
        else
        {
            Debug.LogWarning("Failed to draw card.");
        }
    }
}
