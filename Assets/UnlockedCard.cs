using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockedCard : MonoBehaviour
{
    [SerializeField] private GameObject cardtoadd;
    [SerializeField] private Loadout loadout;
    
    public void Addcardtoloadout()
    {
        loadout.AddToLoadout(cardtoadd);
    }
}
