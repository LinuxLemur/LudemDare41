using System.Collections;
using System.Collections.Generic;
using Dnaiel.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Image CurrentHealthBar;

    public float CurrentHEalth;
    public float Maxhealth;

    private void Awake()
    {
        if (CurrentHealthBar == null)
        {
            Debug.LogError("Health Bar Image not assigned");
        }
    }

    public void UpdateHealthBar()
    {
        float ratio = CurrentHEalth / Maxhealth;

        if (ratio < 0)
            ratio = 0;

        CurrentHealthBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }
}