using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockedCard : MonoBehaviour
{
    [SerializeField] private GameObject cardtoadd;
    private Loadout loadout;

    private void OnEnable ()
    {
        loadout = GameObject.FindObjectOfType<Loadout> ();
    }
    public void Addcardtoloadout ()
    {
        loadout.AddToLoadout (cardtoadd);
    }
}