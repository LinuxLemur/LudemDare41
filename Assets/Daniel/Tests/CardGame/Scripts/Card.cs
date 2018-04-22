using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
internal sealed class Card : MonoBehaviour
{
    [SerializeField]
    private Ability ability;

    public Ability Ability
    {
        get { return this.ability; }
    }

    public Sprite Sprite
    {
        get { return this.GetComponent<Image>().sprite; }
    }
}
